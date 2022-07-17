using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject explosion;
    public GameObject hitExplosion;
    void Awake(){
        Invoke("DestroyObject",0.1f);
    }

    void DestroyObject(){
        //explosão casual
        Instantiate(hitExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        //explosão HITEI ALGO!
        /*
        Instantiate(hitExplosion, transform.position, Quaternion.identity);
        DestroyObject();*/
    }
}
