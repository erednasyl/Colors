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
            ChangeColors.Instance.ToNotan();
        }    


        if (currColorState == 2 && isChangeable)
        {
            ChangeColors.Instance.ToChiao();
        }    


        if (currColorState == 3 && isChangeable)
        {
            ChangeColors.Instance.ToColor();
        }        
    }
}
