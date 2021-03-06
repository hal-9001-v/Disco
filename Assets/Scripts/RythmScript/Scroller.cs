using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{

    public float beatTempo;
    public float originalBeatTempo;
    public bool hasStarted;
    public float fps;

    public List<ArrowObject> Arrows;

    private void Awake()
    {
        Arrows = new List<ArrowObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        originalBeatTempo = beatTempo;
        hasStarted = true;
        fps = 1.0f / (float)Time.deltaTime;
        beatTempo = originalBeatTempo / fps;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fps = 1.0f / (float)Time.deltaTime;
        beatTempo = originalBeatTempo / fps;

        if (!hasStarted)
        {
            //hasStarted = true;
        }
        else
        {
            foreach (ArrowObject arrow in Arrows)
            {
                arrow.transform.position -= new Vector3(0f, 100 * beatTempo * Time.deltaTime, 0f);
            }
        }
    }
}
