using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //ArrowGOs
    public GameObject leftArrow;
    public GameObject upArrow;
    public GameObject downArrow;
    public GameObject rightArrow;

    //Arrow Logic
    public GameObject currentArrow;
    private bool waiting;
    private bool standBy;

    //BeatCalculator GOs
    int i;
    private bool hasEnded;
    public Scroller levelScroller;
    private float notePauseTime;
    public char[] charray;
    enum CurrentArrow{
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,

    }

    private void Awake()
    {
        hasEnded = false;
        levelScroller = FindObjectOfType<Scroller>();
        i = 0;
        waiting = false;
        standBy = false;
        StoreSong();
    }
 

    // Update is called once per frame
    void FixedUpdate()
    {

        notePauseTime = levelScroller.fps / levelScroller.originalBeatTempo;
        if (!waiting && !standBy && !hasEnded) {
            Pause(notePauseTime);
            Generator();
            Spawn(currentArrow);
        }

    }

    public void Generator() {

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
                    for (int j = i+1; j < charray.Length; j++) {
                        if (charray[j] != 'p') stopString += charray[j];
                        else break;
                    }
                    float stop = float.Parse(stopString, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                    StandBy(stop);
                    break;
                case ',':
                    break;
                case '/':
                     hasEnded = true;
                    break;
                default:
                    currentArrow = null;
                    break;     
            }
            i++;
    }

    public void StoreSong()
    {
        int j = 0;  
        string song = "^,^,<,<,>,-5p,<,>,>,>/";
        charray = new char[song.Length];
        foreach (char c in song)
        {

            charray[j] = c;
            j++;
        }
    }

    public void SelectCurrentArrow(int arrow) {

        switch (arrow) {

            case ((int)CurrentArrow.Up):
                currentArrow = upArrow;
                break;
            case ((int)CurrentArrow.Down):
                currentArrow = downArrow ;
                break;
            case ((int)CurrentArrow.Left):
                currentArrow = leftArrow;
                break;
            case ((int)CurrentArrow.Right):
                currentArrow = rightArrow;
                break;

        }

    }

    public void Spawn(GameObject arrow) {


        if (arrow != null)
        {
            Instantiate(arrow, new Vector3(arrow.transform.position.x, arrow.transform.position.y, arrow.transform.position.z), Quaternion.identity);
            Debug.Log("Spawned!");

        }
    }

    public void Pause(float wait) {

        waiting = true;
        StartCoroutine(PauseNum(wait));

    }

    private IEnumerator PauseNum(float wait) {

        yield return new WaitForSecondsRealtime(wait);
        waiting = false;

    }
    public void StandBy(float sby) {

        standBy = true;
        StartCoroutine(StandByNum(sby));

    }

    private IEnumerator StandByNum(float sby) {

        yield return new WaitForSecondsRealtime(sby);
        standBy = false;

    }

    public void SetBeatTempo(float newBeatTempo) {

        levelScroller.originalBeatTempo = newBeatTempo;
        
    }

}
