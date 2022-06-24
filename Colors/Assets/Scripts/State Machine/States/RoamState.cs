using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : State
{
    public override void Enter(){
        base.Enter();
        InputController.instance.OnMove+=OnMove;
        InputController.instance.OnClick+=OnClick;
    }

    public override void Exit(){
        base.Exit();
        InputController.instance.OnMove-=OnMove;
        InputController.instance.OnClick-=OnClick;
    }

    void OnMove(object sender, object args){
        Vector3Int input = (Vector3Int)args;
        TileLogic t = Board.GetTile(PlayerController.instance.position + input);

        if(t!=null){
            if(PlayerController.instance.tile != null){
                if(PlayerController.instance.tile.floor != t.floor){
                    Debug.Log("Jump!");
                }}
            PlayerController.instance.position = t.pos;
            PlayerController.instance.tile = t;
            PlayerController.instance.spriteRenderer.sortingOrder = t.contentOrder;
            LeanTween.move(PlayerController.instance.transform.gameObject, t.worldPos, 0.2f);
        }
    }

    public virtual void OnClick(object sender, object args){
        Touch touch = (Touch) args;
        Vector3 pos;
        GameObject bullet;
        if (touch.phase == TouchPhase.Began){
            Debug.Log("Atirou!");
            bullet = Instantiate(PlayerController.instance.bulletPrefab, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);
            pos = Camera.main.ScreenToWorldPoint(touch.position);
            Debug.Log(pos);
            LeanTween.move(bullet, pos,0.2f);
        }
    }
}