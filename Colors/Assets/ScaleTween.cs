using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaleTween : MonoBehaviour
{
    bool click = false;
    bool pause = false;
    public void OnClose()
    {
        LeanTween.scale(gameObject, new Vector3(0,0,0), 0.1f);
    }

    public void OnCloseStart()
    {
        LeanTween.scale(gameObject, new Vector3(0,0,0), 0.1f);
        //GameManager.gameStart = true;

    }

    public void OnOpenEnd(){
        LeanTween.scale(gameObject, new Vector3(1,1,1), 0.1f);
        //GameManager.restart = true;
    }

    public void OnOpen(){
        LeanTween.scale(gameObject, new Vector3(1,1,1), 0.1f);
    }

    public void HandleInstruction(){
        click = true;
        if (click){
            if (transform.localScale == new Vector3(0,0,0))
            {
                OnOpen();
                click=false;
            }
            else{
                OnClose();
                click=false;
            }
        }
    }

    public void Pause(){
        if (!pause)
        {   
            pause = true;
        }
        else{
            pause = false;
        }

        if (pause)
        {
            //GameManager.Instance.gameTimeScale = 0f;
        }
        else{
            //GameManager.Instance.gameTimeScale = 1f;
        }
    }

    void DestroyMe(){
        gameObject.SetActive(false);
    }
}
