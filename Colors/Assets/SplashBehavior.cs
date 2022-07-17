using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashBehavior : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0){SceneTransitions.signalToChange = 1;}
    }
}
