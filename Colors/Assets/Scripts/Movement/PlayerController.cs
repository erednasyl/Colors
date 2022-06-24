using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public TileLogic tile;
    public Vector3Int position;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    
    public GameObject bulletPrefab;

    void Awake(){
        instance = this;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
}