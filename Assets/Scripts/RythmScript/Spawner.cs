using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool isPlaying { get; private set; }

    //ArrowGOs
    [Header("Referencees")]
    public GameObject _leftArrowPrototype;
    public GameObject _upArrowPrototype;
    public GameObject _downArrowPrototype;
    public GameObject _rightArrowPrototype;

    RythmCommand _rythmCommand;

    //Arrow Logic
    float _elapsedTime;

    //BeatCalculator GOs
    Scroller _scroller;
    private float notePauseTime;
    public char[] songCode;
    int songCodeIndex;

    bool _displayCards;

    enum CurrentArrow
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,

    }

    private void Awake()
    {
        _scroller = FindObjectOfType<Scroller>();

        _rythmCommand = FindObjectOfType<RythmCommand>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPlaying)
        {
            if (_displayCards)
            {
                if (_scroller.Arrows.Count == 0)
                {
                    _rythmCommand.DisplayCards();
                    _rythmCommand.HideButtons();

                    _displayCards = false;

                    PauseSong();
                }
            }
            else
            {
                if (songCode != null && songCodeIndex < songCode.Length)
                {
                    PlayNote();
                }
            }

        }
    }

    void PlayNote()
    {
        notePauseTime = _scroller.fps / _scroller.originalBeatTempo;
        if (_elapsedTime >= notePauseTime)
        {
            CheckCode(songCode[songCodeIndex]);
            songCodeIndex++;

            _elapsedTime = 0;
        }
        else
        {
            _elapsedTime += Time.fixedDeltaTime;
        }
    }

    public void PauseSong()
    {
        isPlaying = false;
    }

    public void ContinueSong()
    {
        isPlaying = true;
    }

    public void StartPlaying(string song)
    {
        isPlaying = true;

        songCode = new char[song.Length];
        songCodeIndex = 0;

        for (int i = 0; i < song.Length; i++)
        {
            songCode[i] = song[i];
        }
    }

    public void CheckCode(char c)
    {
        switch (c)
        {
            case '^':
                Spawn(_upArrowPrototype);
                break;
            case 'v':
                Spawn(_downArrowPrototype);
                break;
            case '<':
                Spawn(_leftArrowPrototype);
                break;
            case '>':
                Spawn(_rightArrowPrototype);
                break;
            case '-':
                /*string stopString = null;
                for (int j = i + 1; j < charray.Length; j++)
                {
                    if (charray[j] != 'p') stopString += charray[j];
                    else break;
                }
                float stop = float.Parse(stopString, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                StandBy(stop);
                */
                break;
            case ',':
                break;
            case '/':

                break;

            //Cards
            case 'c':
                _displayCards = true;
                break;

            default:
                break;
        }
    }

    public void Spawn(GameObject arrow)
    {
        if (arrow != null)
        {
            var newArrow = Instantiate(arrow, new Vector3(arrow.transform.position.x, arrow.transform.position.y, arrow.transform.position.z), Quaternion.identity).GetComponent<ArrowObject>();
            newArrow.Initialize(_scroller);

            _scroller.Arrows.Add(newArrow);
            Debug.Log("Spawned!");

        }
    }

    public void SetBeatTempo(float newBeatTempo)
    {
        _scroller.originalBeatTempo = newBeatTempo;
    }

}
