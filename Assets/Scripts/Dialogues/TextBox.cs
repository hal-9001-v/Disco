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


    [Header("Settings")]
    [Range(0.01f, 1)]
    public float typeDelay;

    Coroutine typing;

    Queue<string> lines;
    string currentLine;

    Dialogue currentDialogue;

    bool endOfLine;
    bool displayingDialogue;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        lines = new Queue<string>();

        hide();
    }

    public void startDialogue(Dialogue d)
    {

        if (!displayingDialogue)
        {


            currentDialogue = d;

            myGroup.transform.position = currentDialogue.getBoxPosition();
            nameMesh.text = currentDialogue.getDialogueName();

            show();
            displayingDialogue = true;

            if (typing != null)
                StopCoroutine(typing);

            lines.Clear();
            foreach (string s in d.getLines())
            {
                lines.Enqueue(s);
            }


            typing = StartCoroutine(typeLine());
        }


    }

    void startNextLine()
    {
        if (!Pauser.isPaused)
        {
            if (typing != null)
                StopCoroutine(typing);


            if (lines.Count == 0)
            {
                if (currentDialogue.afterText != null)
                    currentDialogue.afterText.Invoke();

                hide();
            }
            else
            {
                typing = StartCoroutine(typeLine());
            }
        }


    }

    IEnumerator typeLine()
    {
        textMesh.text = "";
        currentLine = lines.Dequeue();
        endOfLine = false;

        foreach (char c in currentLine.ToCharArray())
        {
            textMesh.text += c;

            playTypingSound();

            yield return new WaitForSeconds(typeDelay);

        }

        yield return null;

    }


    void fillCurrentLine()
    {
        if (!Pauser.isPaused)
        {

            if (typing != null)
                StopCoroutine(typing);

            textMesh.text = currentLine;
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
