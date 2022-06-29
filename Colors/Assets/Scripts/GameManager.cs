using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<VolumeProfile> profileList;
    public VolumeProfile currentProfile;
    public Volume volume;

    void Awake()
    {
        Instance = this;
        volume.profile = currentProfile;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
