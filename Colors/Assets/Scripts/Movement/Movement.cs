using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Sprite[] spriteList;
    public bool test;
    float moveSpeed = 0.2f;
    float jumpHeight = 1f;
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
                currTile = Board.instance.tiles[goal];
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
                if (currTile.floor != t.floor){
                    StartCoroutine(Jump(t));
                }
                LeanTween.move(transform.gameObject, t.worldPos, 0.2f);
            }
           
        }
        else if (Input.GetKey(KeyCode.A)){
            if (counter >= 0.2f)
            {
                SR.sprite = spriteList[5];
                currTile = Board.instance.tiles[goal];
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
                if (currTile.floor != t.floor){
                    StartCoroutine(Jump(t));
                }
                LeanTween.move(transform.gameObject, t.worldPos, 0.2f);
            }
        }
        else if (Input.GetKey(KeyCode.S)){
            if (counter >= 0.2f)
            {
                SR.sprite = spriteList[7];
                currTile = Board.instance.tiles[goal];
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
                if (currTile.floor != t.floor){
                    StartCoroutine(Jump(t));
                }
                LeanTween.move(transform.gameObject, t.worldPos, 0.2f);
            }
        }
        else if (Input.GetKey(KeyCode.D)){
            if (counter >= 0.2f)
            {
                SR.sprite = spriteList[1];
                currTile = Board.instance.tiles[goal];
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
                if (currTile.floor != t.floor){
                    StartCoroutine(Jump(t));
                }
                LeanTween.move(transform.gameObject, t.worldPos, 0.2f);
            }
        }
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