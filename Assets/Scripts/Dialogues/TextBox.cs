using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class TextBox : InputComponent
{
    AudioSource audioSource;

    public CanvasGroup myGroup;
    [Header("Text Meshes")]
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI nameMesh;

    public TextMeshProUGUI[] answersMeshes;
    public Animator[] answersAnimators;

    const string selectAnswerTrigger = "Select";
    const string unselectAnswerTrigger = "Unselect";

    [Header("Settings")]
    [Range(0.01f, 1)]
    public float typeDelay;

    Coroutine typing;

    Queue<string> lines;
    string currentLine;

    string[] answers;
    int currentAnswer = -1;

    Dialogue currentDialogue;

    bool endOfLine;
    bool displayingDialogue;
    bool waitingForAnswer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        lines = new Queue<string>();

        hide();
    }

    public void startDialogue(Dialogue d)
    {
        Debug.Log("Starting Dialogue " + d.name);

        currentDialogue = d;
        currentDialogue.atStart.Invoke();

        currentAnswer = -1;

        myGroup.transform.position = currentDialogue.getBoxPosition();
        nameMesh.text = currentDialogue.getDialogueName();

        show();
        displayingDialogue = true;

        hideAnswers();

        if (typing != null)
            StopCoroutine(typing);

        lines.Clear();
        foreach (string s in d.getLines())
        {
            lines.Enqueue(s);
        }


        typing = StartCoroutine(typeLine());


    }

    void startNextLine()
    {
        if (!Pauser.isPaused)
        {
            if (typing != null)
                StopCoroutine(typing);

            typing = StartCoroutine(typeLine());
        }


    }

    IEnumerator typeLine()
    {

        currentLine = lines.Dequeue();

        textMesh.text = currentLine;

        endOfLine = false;



        for (int i = 0; i <= currentLine.Length; i++)
        {

            textMesh.maxVisibleCharacters = i;

            playTypingSound();

            yield return new WaitForSeconds(typeDelay);


        }

        endOfLine = true;


    }


    void fillCurrentLine()
    {
        if (!Pauser.isPaused)
        {

            if (typing != null)
                StopCoroutine(typing);

            textMesh.maxVisibleCharacters = textMesh.text.Length;
            endOfLine = true;
        }


    }

    void playTypingSound()
    {
        //Do something
        if (audioSource != null && !audioSource.isPlaying)
            audioSource.Play();

    }


    public void hide()
    {
        myGroup.alpha = 0;
        displayingDialogue = false;

    }

    public void show()
    {
        myGroup.alpha = 1;

    }

    void displayAnswers()
    {

        answers = currentDialogue.getAnswers();
        waitingForAnswer = true;

        if (answers != null && answers.Length > 0)
        {
            if (answersMeshes.Length < answers.Length)
            {
                Debug.LogWarning("AnswerMeshes are " + answersMeshes.Length + " and Text Container have " + currentDialogue.myLines.englishAnswers.Length + " answers!");
            }

            //Show Meshes
            for (int i = 0; i < answers.Length; i++)
            {
                answersMeshes[i].enabled = true;
                answersMeshes[i].text = answers[i];

            }

            selectAnswer(0);
        }
        else
            hide();

    }

    void selectAnswer(int i)
    {
        if (i < 0)
        {
            i = answers.Length - 1;
        }
        else if (i >= answers.Length)
            i = 0;

        if (currentAnswer != -1)
        {
            answersAnimators[currentAnswer].SetTrigger(unselectAnswerTrigger);
        }
        currentAnswer = i;
        answersAnimators[currentAnswer].SetTrigger(selectAnswerTrigger);
    }

    void confirmAnswer()
    {
        if (currentDialogue.afterText != null)
            currentDialogue.afterText.Invoke();

        if (currentDialogue.nextDialogues != null && currentDialogue.nextDialogues.Length > 0 && currentAnswer >= 0)
        {
            startDialogue(currentDialogue.nextDialogues[currentAnswer]);
        }

        waitingForAnswer = false;

    }

    void hideAnswers()
    {
        for (int i = 0; i < answersMeshes.Length; i++)
        {
            answersMeshes[i].enabled = false;
        }

    }


    public override void setInput(NormalInput inputs)
    {
        inputs.Map.Text.performed += ctx =>
        {
            if (displayingDialogue)
            {
                if (waitingForAnswer)
                {
                    confirmAnswer();
                }
                else
                {
                    if (endOfLine)
                    {
                        if (lines.Count != 0)
                            startNextLine();
                        else
                            displayAnswers();
                    }
                    else
                    {
                        fillCurrentLine();
                    }
                }

            }

        };

        inputs.Map.ChangeAnswer.performed += ctx =>
        {
            if (ctx.ReadValue<float>() < 0)
                selectAnswer(currentAnswer + 1);

            else if (ctx.ReadValue<float>() > 0)
                selectAnswer(currentAnswer - 1);
        };
    }

}
