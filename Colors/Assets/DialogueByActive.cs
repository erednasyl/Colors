using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueByActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
