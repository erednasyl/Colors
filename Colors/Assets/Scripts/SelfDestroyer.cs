using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    public void DestroyObject(){
        Destroy(gameObject);
    }
}
