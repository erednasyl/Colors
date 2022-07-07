using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public TileBase[] tiles;

    public TileBase nextTile;

    public TileBase realTile;

    public bool isWalkable, isSwappable;

    public float movSpeed;
}
