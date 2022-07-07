using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnColors : MonoBehaviour
{ 
    public static ShowOnColors Instance;
    void Awake(){
        Instance = this;
        gameObject.SetActive(false);
    }
    public void Setup(){
        gameObject.SetActive(true);
    }
    public void Disable(){
        gameObject.SetActive(false);
    }

}
