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
        int button = (int) args;

        if (button == 1){
            Debug.Log("Atirou!");
        }

        else if (button == 2){
            Debug.Log("Morreu!");
            StateMachineController.instance.ChangeTo<NotanState>();
        }
    }
}