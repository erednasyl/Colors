using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCinematicControl : MonoBehaviour
{
    [SerializeField] int currColorState;
    [SerializeField] bool isChangeable;

    void Update()
    {
        if (currColorState == 1 && isChangeable)
        {
            MapManager.Instance.ToNotan();
        }    


        if (currColorState == 2 && isChangeable)
        {
            MapManager.Instance.ToChiao();
        }    


        if (currColorState == 3 && isChangeable)
        {
            MapManager.Instance.ToColor();
        }        
    }
}
