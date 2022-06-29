using System.Collections.Generic;
 
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//https://answers.unity.com/questions/1526663/detect-click-on-canvas.html

public class CheckClicks : MonoBehaviour
{
    // Normal raycasts do not work on UI elements, they require a special kind
    GraphicRaycaster raycaster;
    public static bool clickUI = false;
        void Awake()
        {
        // Get both of the components we need to do this
        this.raycaster = GetComponent<GraphicRaycaster>();
    }
 
    void Update()
    {
        //Check touches
        if (Input.touchCount > 0)
        {   
            Touch t = Input.GetTouch(0);
            //Set up the new Pointer Event
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();
 
            //Raycast using the Graphics Raycaster and mouse click position
            pointerData.position = t.position;
            this.raycaster.Raycast(pointerData, results);
 
            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            if (results.Count == 0)
            {
                clickUI = false;
            }
            else{
                clickUI = true;
            }
            
            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
            }
         }
     }
 }