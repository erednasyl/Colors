using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Sprite[] spriteList;
    public bool test;
    public Vector3Int goal;
    SpriteRenderer SR;
    Transform jumper;
    TileLogic currTile;
    TileLogic t;

    void Start(){
        jumper = transform.Find("Jumper");
        SR = GetComponentInChildren<SpriteRenderer>();

        t = Board.instance.tiles[goal];
        //Vector3 startPos = transform.position;
        transform.position = t.worldPos;
    }

float counter = 0f;
    void Update(){
        counter+= Time.deltaTime;
        if (Input.GetKey(KeyCode.W)){
            if (counter >= 0.2f)
            {
                SR.sprite = spriteList[3];
                if (Input.GetKey(KeyCode.A)){
                    SR.sprite = spriteList[4];
                    goal.y+=1;
                }
                if (Input.GetKey(KeyCode.D)){
                    SR.sprite = spriteList[2];
                    goal.y-=1;
                }
                goal.x += 1;    
                counter = 0;                
                t = Board.instance.tiles[goal];
                //transform.position = t.worldPos;
                LeanTween.move(transform.gameObject, t.worldPos, 0.2f);
            }
        }
        else if (Input.GetKey(KeyCode.A)){
            if (counter >= 0.2f)
            {
                SR.sprite = spriteList[5];
                if (Input.GetKey(KeyCode.W)){
                    SR.sprite = spriteList[4];
                    goal.x+=1;
                }
                if (Input.GetKey(KeyCode.S)){
                    SR.sprite = spriteList[6];
                    goal.x-=1;
                }
                goal.y += 1;    
                counter = 0;                
                t = Board.instance.tiles[goal];
                LeanTween.move(transform.gameObject, t.worldPos, 0.2f);
            }
        }
        else if (Input.GetKey(KeyCode.S)){
            if (counter >= 0.2f)
            {
                SR.sprite = spriteList[7];
                if (Input.GetKey(KeyCode.A)){
                    SR.sprite = spriteList[6];
                    goal.y+=1;
                }
                if (Input.GetKey(KeyCode.D)){
                    SR.sprite = spriteList[0];
                    goal.y-=1;
                }
                goal.x -= 1;    
                counter = 0;                
                t = Board.instance.tiles[goal];
                LeanTween.move(transform.gameObject, t.worldPos, 0.2f);
            }
        }
        else if (Input.GetKey(KeyCode.D)){
            if (counter >= 0.2f)
            {
                SR.sprite = spriteList[1];
                if (Input.GetKey(KeyCode.W)){
                    SR.sprite = spriteList[2];
                    goal.x+=1;
                }
                if (Input.GetKey(KeyCode.S)){
                    SR.sprite = spriteList[0];
                    goal.x-=1;
                }
                goal.y -= 1;    
                counter = 0;                
                t = Board.instance.tiles[goal];
                LeanTween.move(transform.gameObject, t.worldPos, 0.2f);
            }
        }
        /*
        if (test){
            test = false;
            StopAllCoroutines();
            StartCoroutine(Move());
        }*/
    }
    IEnumerator Move(Vector3 startPos, Vector3 endPos){
        yield return null;
        float totalTime = 1f;
        float tempTime = 0;
        float perc;
        while (transform.position != endPos){
            tempTime += Time.deltaTime;
            perc = tempTime/totalTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
            yield return null;
        }
    }
/*
    IEnumerator Move(){
        yield return null;
        
        //transform.position = t.worldPos;
        float totalTime = 0.2f;
        float tempTime = 0;
        float perc;

        if (currTile == null){
            currTile = t;
        }
        if (currTile.floor != t.floor){
            StartCoroutine(Jump(t, totalTime));
        }
        while (transform.position != endPos){
            tempTime += Time.deltaTime;
            perc = tempTime/totalTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
            yield return null;
        }

        SR.sortingOrder = t.contentOrder;
        t.content = this.gameObject;
    }

    IEnumerator Jump(TileLogic t, float totalTime){
        Vector3 halfwayPos;
        Vector3 startPos = halfwayPos = jumper.localPosition;
        halfwayPos.y += 0.5f;
        float tempTime = 0;

        while (jumper.localPosition!=halfwayPos){
            tempTime += Time.deltaTime;
            float perc = tempTime/(totalTime/2);
            jumper.localPosition = Vector3.Lerp(startPos, halfwayPos, perc);
            yield return null;
        }

        tempTime = 0;

        while(jumper.localPosition!=startPos){
            tempTime += Time.deltaTime;
            float perc = tempTime/(totalTime/2);
            jumper.localPosition = Vector3.Lerp(halfwayPos, startPos, perc);
            yield return null;
        }
    */
} 