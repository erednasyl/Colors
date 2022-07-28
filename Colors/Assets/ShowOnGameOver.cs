using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShowOnGameOver : MonoBehaviour
{
    public GameObject js;
    public void Setup(){
        gameObject.SetActive(true);
        gameObject.GetComponentInChildren<Button>().onClick.Invoke(); 
        js.SetActive(false);
    }
}
