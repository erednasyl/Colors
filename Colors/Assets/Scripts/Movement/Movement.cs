using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool test;
    public Vector3Int goal;
    SpriteRenderer SR;
    Transform jumper;
    TileLogic currTile;
    
    void Start(){
        jumper = transform.Find("Jumper");
        SR = GetComponentInChildren<SpriteRenderer>();
    }

    void Update(){
        if (test){
            test = false;
            StopAllCoroutines();
            StartCoroutine(Move());
        }
    }

    IEnumerator Move(){
        yield return null;
        TileLogic t = Board.instance.tiles[goal];
        //transform.position = t.worldPos;

        Vector3 startPos = transform.position;
        Vector3 endPos = t.worldPos; //qual a diff de worldPos e pos?

        float totalTime = 1;
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
    }
}