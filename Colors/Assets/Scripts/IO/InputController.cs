using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DelegateModel(object sender, object args);
public class InputController : MonoBehaviour
{
    float h;
    float v;
    Touch t;

    public static InputController instance;
    
    public DelegateModel OnMove;
    public DelegateModel OnClick;

    public Joystick joystick;

    void Awake(){
        instance = this;
        joystick = FindObjectOfType<Joystick>();
    }

    void Update()
    {
        //fazer a ordem da layer dela subir qnd ela subir no bichinho
        //fazer ela alternar os colliders (para ela poder andar por trás dos tiles enquanto não tiver tocado na escada)
        if (joystick.Vertical >= 0.2f){
            PlayerController.instance.spriteRenderer.sprite = PlayerController.instance.spriteList[4];
            v = 1f;
            h = 0f;
            if (joystick.Horizontal >= 0.2f){
                PlayerController.instance.spriteRenderer.sprite = PlayerController.instance.spriteList[3];
                h=1f;
                v /= 2f;
            }
            else if(joystick.Horizontal <= -0.2f){
                PlayerController.instance.spriteRenderer.sprite = PlayerController.instance.spriteList[5];
                h=-1f;
                v /= 2f;
            }
        }

        else if (joystick.Vertical <= -0.2f){
            PlayerController.instance.spriteRenderer.sprite = PlayerController.instance.spriteList[0];
            v = -1;
            h = 0;
            if (joystick.Horizontal >= 0.2f){
                PlayerController.instance.spriteRenderer.sprite = PlayerController.instance.spriteList[1];
                h=1;
                v /= 2f;
            }
            else if(joystick.Horizontal <= -0.2f){
                PlayerController.instance.spriteRenderer.sprite = PlayerController.instance.spriteList[7];
                h=-1;
                v /= 2f;
            }
        }

        else if (joystick.Horizontal >= 0.2f){
            PlayerController.instance.spriteRenderer.sprite = PlayerController.instance.spriteList[2];
            v = 0;
            h = 1;
            if (joystick.Vertical >= 0.2f){
                PlayerController.instance.spriteRenderer.sprite = PlayerController.instance.spriteList[3];
                v=1;
                v /= 2f;
            }
            else if(joystick.Vertical <= -0.2f){
                PlayerController.instance.spriteRenderer.sprite = PlayerController.instance.spriteList[1];
                v=-1;
                v /= 2f;
            }
        }

        else if (joystick.Horizontal <= -0.2f){
            PlayerController.instance.spriteRenderer.sprite = PlayerController.instance.spriteList[6];
            v = 0;
            h = -1;
            if (joystick.Vertical >= 0.2f){
                PlayerController.instance.spriteRenderer.sprite = PlayerController.instance.spriteList[5];
                v=1;
                v /= 2f;
            }
            else if(joystick.Vertical <= -0.2f){
                PlayerController.instance.spriteRenderer.sprite = PlayerController.instance.spriteList[7];
                v=-1;
                v /= 2f;
            }
        }

        else {
            v = 0;
            h = 0;
        }
        
        Vector2 moved = new Vector2(0, 0);

        if(h!=0){
            moved.x = h;
        }
        if(v!=0){
            moved.y = v;
        }
        
        if(OnMove!=null){
            Debug.Log(moved);
            OnMove(null, moved);
        }

        if (Input.touchCount > 0)
        {   
            t = Input.GetTouch(0);
            OnClick(null, t);
        }
    }
}