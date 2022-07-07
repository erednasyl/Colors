using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Camera main;
    public List<VolumeProfile> profileList;
    public VolumeProfile currentProfile;
    public Volume volume;

    public Light2D globalLight;
    public GameObject[] pointLights;
    
    void Awake()
    {
        main.backgroundColor = Color.black;
        Instance = this;
        volume.profile = currentProfile;
    }

}
