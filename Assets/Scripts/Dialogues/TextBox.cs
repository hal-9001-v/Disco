using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class TextBox : InputComponent, IPauseObserver
{
    [Header("References")]
    AudioSource _audioSource;
    [SerializeField] CanvasGroup _myGroup;

    [Header("Text Meshes")]
    [SerializeField] TextMeshProUGUI _textMesh;
    [SerializeField] TextMeshProUGUI _nameMesh;

    [SerializeField] TextMeshProUGUI[] _answersMeshes;
    [SerializeField] Animator[] _answersAnimators;

    [Header("Settings")]
    [Range(0.01f, 1)]
    [SerializeField] float _typeDelay;

    Queue<string> _lines;

    Dialogue _currentDialogue;

    public bool DisplayingDialogue { get; private set; }

    bool _readyForNewLine;

    bool _gameIsPaused;

    //It can happen that input that fills a line gets activated right after dialogue starts due to an interaction(It is the same button) and it gets automatically filled.
    //For that, first frame musnt have any input
    bool _firstTypingFramePassed;

    bool _waitingForAnswer;

    AnswerSelector _answerSelector;

    //Called everytime TextBox is shown
    public Action StartDialogueAction;
    //Called everytime TextBox is hidden
    public Action EndDialogueAction;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _lines = new Queue<string>();

        _answerSelector = new AnswerSelector(_answersMeshes);

        Hide();

        InitializeObserver();
    }

    public void StartDialogue(Dialogue d)
    {
        if (!DisplayingDialogue)
        {
            Debug.Log("Starting Dialogue " + d.name);

            _currentDialogue = d;
            _waitingForAnswer = false;

            _myGroup.transform.position = _currentDialogue.GetBoxPosition();
            _nameMesh.text = _currentDialogue.GetDialogueName();

            Show();

            _lines.Clear();

            foreach (string s in d.GetLines())
            {
                _lines.Enqueue(s);
            }

            StartCoroutine(TypeLine(_lines.Dequeue()));
        }

    }

    //Start a new line or displaye new Answers. In case there are no answers to display, hide.
    void StartNextLine()
    {
        if (_readyForNewLine)
        {
            //If there are more lines
            if (_lines.Count != 0)
            {
                StartCoroutine(TypeLine(_lines.Dequeue()));
            }
            else
            {
                //Since text has ended, display answers if there is any. 
                var answers = _currentDialogue.GetAnswersTexts();
                if (answers != null && answers.Length != 0)
                {
                    _answerSelector.DisplayAnswers(answers, _currentDialogue.GetAnswersActions());
                    _waitingForAnswer = true;

                }
                else //There are no answers to display, close Dialogue
                {
                    Hide();

                    _currentDialogue.AfterText.Invoke();

                }
            }
        }
    }

    IEnumerator TypeLine(string line)
    {
        //Line must be complete for a new line to come
        _readyForNewLine = false;

        //Make sure no input happens during first typing frame.
        _firstTypingFramePassed = false;

        _textMesh.text = line;
        _textMesh.maxVisibleCharacters = 0;

        while (_textMesh.maxVisibleCharacters != line.Length)
        {
            _textMesh.maxVisibleCharacters++;
            PlayTypingSound();


            if (_readyForNewLine)
            {
                _textMesh.maxVisibleCharacters = line.Length;
            }

            yield return new WaitForSeconds(_typeDelay);

            _firstTypingFramePassed = true;
        }

        _readyForNewLine = true;

    }

    void PlayTypingSound()
    {
        //Do something
        if (_audioSource != null && !_audioSource.isPlaying)
            _audioSource.Play();

    }

    public void Hide()
    {
        _myGroup.alpha = 0;
        DisplayingDialogue = false;

        _answerSelector.UnselectAll();

        EndDialogueAction.Invoke();
    }

    public void Show()
    {
        _myGroup.alpha = 1;
        DisplayingDialogue = true;

        StartDialogueAction.Invoke();
    }

    public override void SetInput(NormalInput inputs)
    {
        inputs.Map.ConfirmAnswer.performed += ctx =>
        {
            //If game is paused, no input!
            if (_gameIsPaused) return;

            //Nothing should happen if no dialogue is shown
            if (DisplayingDialogue)
            {
                //If waiting for answer, confirm 
                if (_waitingForAnswer)
                {
                    _waitingForAnswer = false;
                    Hide();
                    _answerSelector.ConfirmAnswer();
                }
                //If not waiting for answer, then attend for autofill or next line confirmation
                else
                {
                    //It can happen that _readyForNewLine gets true on the same Frame that a new Line is requested. So, it will get autofilled a line since the start
                    if (_firstTypingFramePassed)
                    {
                        if (_readyForNewLine)
                        {
                            StartNextLine();
                        }
                        else
                        {
                            //Make coroutine fill line fully
                            _readyForNewLine = true;
                        }
                    }
                }
            }


        };


        inputs.Map.ChangeAnswer.performed += ctx =>
        {
            if (ctx.ReadValue<float>() < 0)
            {
                if (_waitingForAnswer)
                    _answerSelector.SelectNextAnswer();
            }

            else if (ctx.ReadValue<float>() > 0)
            {
                if (_waitingForAnswer)
                    _answerSelector.SelectPreviousAnswer();
            }
        };
    }

    public void OnPauseGame()
    {
        _gameIsPaused = true;
    }

    public void OnResumeGame()
    {
        _gameIsPaused = false;
    }

    public void InitializeObserver()
    {
        var pauser = FindObjectOfType<Pauser>();

        if (pauser != null)
        {
            pauser.PauseGameAction += OnPauseGame;
            pauser.ResumeGameAction += OnResumeGame;
        }
    }
}

class AnswerSelector
{
    TextMeshProUGUI[] _answerMeshes;
    TextMeshProUGUI[] _possibleAnswers;
    Animator[] _animators;

    UnityEvent[] _actions;

    int _currentAnswer = 0;

    const string SelectAnswerBool = "Selected";

    public AnswerSelector(TextMeshProUGUI[] answers)
    {
        _answerMeshes = answers;

        _animators = new Animator[answers.Length];

        for (int i = 0; i < answers.Length; i++)
        {
            _animators[i] = answers[i].GetComponent<Animator>();
        }
    }

    public void SelectNextAnswer()
    {
        _currentAnswer++;

        SelectAnswer(ref _currentAnswer);
    }

    public void SelectPreviousAnswer()
    {
        _currentAnswer--;

        SelectAnswer(ref _currentAnswer);
    }

    public void ConfirmAnswer()
    {
        if (_actions != null && _possibleAnswers != null)
        {
            _actions[_currentAnswer].Invoke();
        }
    }

    public void DisplayAnswers(string[] texts, UnityEvent[] actions)
    {

        if (texts.Length != actions.Length) return;

        if (texts.Length > _answerMeshes.Length) return;

        _possibleAnswers = new TextMeshProUGUI[texts.Length];

        for (int i = 0; i < _possibleAnswers.Length; i++)
        {
            _possibleAnswers[i] = _answerMeshes[i];
            _possibleAnswers[i].text = texts[i];
        }

        _actions = actions;


        //Turn invisible all meshes
        for (int i = 0; i < _answerMeshes.Length; i++)
        {
            _answerMeshes[i].enabled = false;
        }

        //Show Meshes wich contain answers
        for (int i = 0; i < _possibleAnswers.Length; i++)
        {
            _possibleAnswers[i].enabled = true;
        }

        _currentAnswer = 0;
        SelectAnswer(ref _currentAnswer);

    }

    public void UnselectAll()
    {
        for (int i = 0; i < _answerMeshes.Length; i++)
        {
            _answerMeshes[i].enabled = false;
            _animators[i].SetBool(SelectAnswerBool, false);
        }
    }

    void SelectAnswer(ref int i)
    {
        if (_possibleAnswers != null)
        {

            if (i < 0)
            {
                i = _possibleAnswers.Length - 1;
            }
            else if (i >= _possibleAnswers.Length)
            {
                i = 0;
            }

            HighlightAnswer(i);


        }
    }

    void HighlightAnswer(int index)
    {

        if (_possibleAnswers != null)
        {
            //Hide and unselect all
            UnselectAll();

            for (int i = 0; i < _possibleAnswers.Length; i++)
            {
                _possibleAnswers[i].enabled = true;
                _animators[i].SetBool(SelectAnswerBool, false);
            }

            _animators[index].SetBool(SelectAnswerBool, true);
        }

    }


}
