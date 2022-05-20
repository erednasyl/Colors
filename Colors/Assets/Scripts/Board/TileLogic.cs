using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLogic
{
    public Vector3Int pos; //Cell position
    public Vector3 worldPos; //Cell world position
    public GameObject content;
    public Floor floor;
    public int contentOrder;
    //public TileType tileType; //tipos de tiles

    public TileLogic(){}

    public TileLogic(Vector3Int pos, Vector3 worldPos, Floor floor){
        this.pos = pos;
        this.worldPos = worldPos;
        this.floor = floor;
        contentOrder = floor.contentOrder;
    }

    public static TileLogic Create(Vector3Int pos, Vector3 worldPos, Floor floor){
        TileLogic tileLogic = new TileLogic(pos, worldPos, floor);
        return tileLogic;
    }
}