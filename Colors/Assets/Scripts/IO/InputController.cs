using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DelegateModel(object sender, object args);
public class InputController : MonoBehaviour
{
    int h;
    int v;
    float counter = 0f;
    float cooldownTimer = 0.2f;
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
        counter+= Time.deltaTime;
        if (counter >= cooldownTimer){
            if (joystick.Vertical >= 0.2f){
                v = 1;
                h = 1;
                if (joystick.Horizontal >= 0.2f){
                    v=0;
                }
                else if(joystick.Horizontal <= -0.2f){
                    h=0;
                }
                counter = 0;
            }
            else if (joystick.Vertical <= -0.2f){
                v = -1;
                h = -1;
                if (joystick.Horizontal >= 0.2f){
                    h=0;
                }
                else if(joystick.Horizontal <= -0.2f){
                    v=0;
                }
                counter = 0;
            }
            else if (joystick.Horizontal >= 0.2f){
                v = -1;
                h = 1;
                if (joystick.Vertical >= 0.2f){
                    v=0;
                }
                else if(joystick.Vertical <= -0.2f){
                    h=0;
                }
                counter = 0;
            }
            else if (joystick.Horizontal <= -0.2f){
                v = 1;
                h = -1;
                if (joystick.Vertical >= 0.2f){
                    h=0;
                }
                else if(joystick.Vertical <= -0.2f){
                    v=0;
                }
                counter = 0;
            }
        }
        else {
            v = 0;
            h = 0;
        }
        
        Vector3Int moved = new Vector3Int(0, 0, 0);

        if(h!=0){
            moved.x = h;
        }
        if(v!=0){
            moved.y = v;
        }
        
        if(moved!=Vector3Int.zero && OnMove!=null){
            Debug.Log(moved);
            OnMove(null, moved);
        }

        bool input = Input.GetKeyDown(KeyCode.W);
        bool input2 = Input.GetKeyDown(KeyCode.E);

        if (Input.touchCount > 0)
        {   
            t = Input.GetTouch(0);
            OnClick(null, t);
        }/*

        if(input){
            OnClick(null, 1);
        }
        if(input2){
            OnClick(null, 2);
        }*/
    }
}