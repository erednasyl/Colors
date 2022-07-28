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

    public float changeScenesTimer;
    
    void Awake()
    {
        changeScenesTimer = 0f;
        main.backgroundColor = Color.black;
        Instance = this;
        volume.profile = currentProfile;
    }

    void Update(){
        if (changeScenesTimer > 0)
        {
            StartCoroutine(ChangeScenes());
        }
    }

    IEnumerator ChangeScenes(){
        yield return new WaitForSeconds(changeScenesTimer);
        changeScenesTimer = 0f;
        SceneTransitions.signalToChange = 1;
    }
}
