using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool IsPlaying { get; private set; }

    //ArrowGOs
    [Header("Referencees")]
    public GameObject _leftArrowPrototype;
    public GameObject _upArrowPrototype;
    public GameObject _downArrowPrototype;
    public GameObject _rightArrowPrototype;

    //Arrow Logic
    public GameObject arrowToCreate;
    private bool waiting;
    private bool standBy;

    //BeatCalculator GOs
    int i;
    public Scroller levelScroller;
    private float notePauseTime;
    public char[] charray;

    enum CurrentArrow
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,

    }

    private void Awake()
    {
        levelScroller = FindObjectOfType<Scroller>();
        i = 0;
        waiting = false;
        standBy = false;

        string song = "^,^,<,<,>,-5p,<,>,>,>/";
        StoreSong(song);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsPlaying && standBy == false)
        {
            notePauseTime = levelScroller.fps / levelScroller.originalBeatTempo;
            if (!waiting)
            {
                Pause(notePauseTime);
                Generator();
                Spawn(arrowToCreate);
            }
        }

    }

    public void StartPlaying()
    {
        IsPlaying = true;
    }

    public void Generator()
    {
        waiting = true;

        switch (charray[i])
        {
            case '^':
                SelectCurrentArrow(0);
                break;
            case 'v':
                SelectCurrentArrow(1);
                break;
            case '<':
                SelectCurrentArrow(2);
                break;
            case '>':
                SelectCurrentArrow(3);
                break;
            case '-':
                string stopString = null;
                for (int j = i + 1; j < charray.Length; j++)
                {
                    if (charray[j] != 'p') stopString += charray[j];
                    else break;
                }
                float stop = float.Parse(stopString, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                StandBy(stop);
                break;
            case ',':
                break;
            case '/':
                break;

            default:
                arrowToCreate = null;
                break;
        }
        i++;
    }

    public void StoreSong(string song)
    {
        charray = new char[song.Length];
        for (int i = 0; i < song.Length; i++)
        {
            charray[i] = song[i];
        }
    }

    public void SelectCurrentArrow(int arrow)
    {
        switch (arrow)
        {
            case ((int)CurrentArrow.Up):
                arrowToCreate = _upArrowPrototype;
                break;
            case ((int)CurrentArrow.Down):
                arrowToCreate = _downArrowPrototype;
                break;
            case ((int)CurrentArrow.Left):
                arrowToCreate = _leftArrowPrototype;
                break;
            case ((int)CurrentArrow.Right):
                arrowToCreate = _rightArrowPrototype;
                break;

        }

    }

    public void Spawn(GameObject arrow)
    {
        if (arrow != null)
        {
            var newArrow = Instantiate(arrow, new Vector3(arrow.transform.position.x, arrow.transform.position.y, arrow.transform.position.z), Quaternion.identity);

            levelScroller.Arrows.Add(newArrow.GetComponent<ArrowObject>());
            Debug.Log("Spawned!");

        }
    }

    public void Pause(float wait)
    {
        waiting = true;
        StartCoroutine(PauseNum(wait));
    }

    private IEnumerator PauseNum(float wait)
    {
        yield return new WaitForSecondsRealtime(wait);
        waiting = false;
    }

    public void StandBy(float sby)
    {
        standBy = true;
        StartCoroutine(StandByNum(sby));
    }

    private IEnumerator StandByNum(float sby)
    {
        yield return new WaitForSecondsRealtime(sby);
        standBy = false;
    }

    public void SetBeatTempo(float newBeatTempo)
    {
        levelScroller.originalBeatTempo = newBeatTempo;
    }

}
