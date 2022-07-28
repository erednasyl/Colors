using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.Experimental.Rendering.Universal;

public class ChangeColors : MonoBehaviour
{
    public static ChangeColors Instance;

    void Awake(){
        Instance = this;
    }

}
