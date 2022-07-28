using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDialogue : MonoBehaviour
{
    public GameObject toActivate;
    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player"))
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
            if(toActivate != null)
                toActivate.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
