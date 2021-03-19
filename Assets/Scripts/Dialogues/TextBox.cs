using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextBox : InputComponent
{

    public CanvasGroup myGroup;
    public TextMeshProUGUI textMesh;

    [Header("Settings")]
    [Range(0.01f, 1)]
    public float typeDelay;

    Coroutine typing;

    Queue<string> lines;
    string currentLine;

    bool endOfLine;
    bool displayingDialogue;

    private void Awake()
    {
        lines = new Queue<string>();

        hide();
    }

    public void startDialogue(string[] dialogue)
    {

        if (!displayingDialogue)
        {

            if (typing != null)
                StopCoroutine(typing);

            displayingDialogue = true;

            lines.Clear();
            foreach (string s in dialogue)
            {
                lines.Enqueue(s);
            }

            show();

            typing = StartCoroutine(typeLine());
        }


    }

    void startNextLine()
    {

        if (typing != null)
            StopCoroutine(typing);


        if (lines.Count == 0)
        {
            hide();
        }
        else
        {
            Debug.Log("New Line!");
            typing = StartCoroutine(typeLine());
        }

    }

    IEnumerator typeLine()
    {
        textMesh.text = "";
        currentLine = lines.Dequeue();

        foreach (char c in currentLine.ToCharArray())
        {
            textMesh.text += c;

            yield return new WaitForSeconds(typeDelay);

        }

        yield return null;

    }

    void fillCurrentLine()
    {

        if (typing != null)
            StopCoroutine(typing);

        textMesh.text = currentLine;
        endOfLine = true;

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


    public override void setInput(NormalInput inputs)
    {
        inputs.Map.Text.performed += ctx =>
        {
            if (displayingDialogue)
            {

                if (endOfLine)
                    startNextLine();
                else
                    fillCurrentLine();

            }


        };
    }

}
