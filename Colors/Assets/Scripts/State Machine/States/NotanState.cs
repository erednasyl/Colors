using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotanState : RoamState
{
    public override void OnClick(object sender, object args){
        int button = (int) args;

        if (button == 1){
            Debug.Log("PEW PEW!");
        }

        else if (button == 2){
            Debug.Log("Masdasdorreu!");
        }
    }
}
