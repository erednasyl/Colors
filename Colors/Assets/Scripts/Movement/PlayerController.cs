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
    public Sprite[] spriteList;
    public GameObject bulletPrefab;
    public Rigidbody2D rb;

    public ShowOnGameOver gameOverScreen;
    void Awake(){
        instance = this;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Portal"))
        {
            if (gameOverScreen != null)
            {
                gameOverScreen.Setup();
            }
        }
    }
}