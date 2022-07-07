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

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
        dialogueBox.SetActive(true);
        toggles.SetActive(true);
        joystick.SetActive(false);

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
        toggles.SetActive(false);
        joystick.SetActive(true);
    }
}
