using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    Queue<string> sentences;
    public TMP_Text text;
    public TMP_Text nameText;

    public GameObject dialogueBox;
    public GameObject toggles;
    public GameObject joystick;

    [SerializeField] int actionOverDeactive;

    public static bool isEventDialogue;

    // Start is called before the first frame update
    void Start()
    {
        isEventDialogue = false;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
        dialogueBox.SetActive(true);
        if (toggles != null && joystick != null)
        {
            toggles.SetActive(true);
            joystick.SetActive(false);
        }

        nameText.text = dialogue.name;
        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        text.text = sentence;
    }

    public void EndDialogue(){
        dialogueBox.SetActive(false);
        StartCoroutine(actOverDeactive());
        if (toggles!= null && joystick != null)
        {
            toggles.SetActive(false);
            joystick.SetActive(true);
        }

    }

    IEnumerator actOverDeactive(){
        yield return null;
        if (actionOverDeactive == 1)
            {
                SceneTransitions.signalToChange = 1;
            }
    }
}
