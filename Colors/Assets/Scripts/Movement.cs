using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool test;
    public Vector3Int goal;
    SpriteRenderer SR;
    
    void Start(){
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
        transform.position = t.worldPos;
        SR.sortingOrder = t.contentOrder;
        t.content = this.gameObject;
    }
}