using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIalogueArea : MonoBehaviour
{
    bool canChat = false;
    void Update(){
        if (canChat)
        {
            //se pressionar no botaozinho de interação que vai aparecer
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    GetComponent<DialogueTrigger>().TriggerDialogue();
                    canChat = false;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player"))
        {
            canChat = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.CompareTag("Player")){
            canChat =  false;
        }
    }
}
