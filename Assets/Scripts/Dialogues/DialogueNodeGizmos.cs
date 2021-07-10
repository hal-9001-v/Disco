using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(Dialogue))]
public class DialogueNodeGizmos : MonoBehaviour
{
#if UNITY_EDITOR
    Dialogue myDialogue;

    [Header("Radius")]
    [Range(0.1f, 5)]
    public float radius;
    public Color radiusColor;

    [Header("Lines")]
    public Color lineColor;

    [Header("Text")]
    public Color textColor;

    string[] answers;

    private void OnDrawGizmos()
    {
        if (myDialogue == null)
        {
            myDialogue = GetComponent<Dialogue>();
            return;
        }
        answers = myDialogue.GetAnswersTexts();


        Gizmos.color = radiusColor;
        Gizmos.DrawWireSphere(transform.position, radius);



        Gizmos.color = lineColor;
        /*
        for (int i = 0; i < myDialogue.nextDialogues.Length; i++)
        {

            if (myDialogue.nextDialogues[i] != null)
            {
                Gizmos.DrawLine(transform.position, myDialogue.nextDialogues[i].transform.position);

                string lineLabel;

                lineLabel = i.ToString();
                if (answers != null && i < answers.Length && answers[i] != null)
                    lineLabel += ": "+answers[i];

                Handles.Label(0.5f * (transform.position + myDialogue.nextDialogues[i].transform.position),lineLabel);
            }

        }


        Handles.color = textColor;
        GUI.color = textColor;
        Handles.Label(transform.position, name);

        */

    }

#endif
}
