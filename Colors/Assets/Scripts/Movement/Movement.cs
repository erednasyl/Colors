using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float jumpHeight = 0.5f;
    public bool test;
    public List<Vector3Int> path;
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
        currTile = Board.GetTile(path[0]);
        transform.position = currTile.worldPos;

        for(int i = 1; i < path.Count; i++){
            TileLogic to = Board.GetTile(path[i]);
            if (to == null)
            {
                continue;
            }
            currTile.content = null;
            if (currTile.floor != to.floor)
            {
                yield return StartCoroutine(Jump(to));
            }else{
                yield return Walk(to);
            }
        }
    }

    IEnumerator Walk(TileLogic to){
        int id = LeanTween.move(transform.gameObject, to.worldPos, moveSpeed).id;
        currTile = to;

        yield return new WaitForSeconds(moveSpeed * 0.5f);

        SR.sortingOrder = to.contentOrder;

        while(LeanTween.descr(id) != null){
            yield return null;
        }

        to.content = this.gameObject;
    }

    IEnumerator Jump(TileLogic to){
        int id1 = LeanTween.move(transform.gameObject, to.worldPos, moveSpeed).id;
        LeanTween.moveLocalY(jumper.gameObject, jumpHeight, moveSpeed*0.5f).setLoopPingPong(1).setEase(LeanTweenType.easeInOutQuad);

        float timeOrderUpdate = moveSpeed;
        if (currTile.floor.tilemap.tileAnchor.y > to.floor.tilemap.tileAnchor.y){
            timeOrderUpdate*=0.85f;
        }else{
            timeOrderUpdate*=0.2f;
        }
        yield return new WaitForSeconds(timeOrderUpdate);
        currTile = to;
        SR.sortingOrder = to.contentOrder;

        while (LeanTween.descr(id1)!= null)
        {
            yield return null;
        }
        to.content = this.gameObject;
    }
}