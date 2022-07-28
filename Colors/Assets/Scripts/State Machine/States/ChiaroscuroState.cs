using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiaroscuroState : RoamState
{
    void Awake(){
        Debug.Log("CHIARO ON!");
    }

    public override void OnClick(object sender, object args){

        Touch touch = (Touch) args;
        Vector3 pos;
        GameObject bullet;

        if (!CheckClicks.clickUI)
        {
            if (touch.phase == TouchPhase.Began){
                Debug.Log("Atirou!");
                bullet = Instantiate(PlayerController.instance.bulletPrefab, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);
                pos = Camera.main.ScreenToWorldPoint(touch.position);
                pos.z = 0;
                LeanTween.move(bullet, pos,0.1f);

                //SwitchingPlayer
                Vector3 screenTouchFar = new Vector3(
                    touch.position.x,
                    touch.position.y,
                    Camera.main.farClipPlane
                );
                Vector3 screenTouchNear = new Vector3(
                    touch.position.x,
                    touch.position.y,
                    Camera.main.nearClipPlane
                );

                int playerLayer = 1 << 9;

                Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenTouchFar);
                Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenTouchNear);

                RaycastHit hit;
                
                Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, playerLayer);

                Debug.DrawRay(worldMousePosNear, worldMousePosFar - worldMousePosNear, Color.red, 3f);

                if(hit.collider != null){
                    GameManager.Instance.currentProfile = GameManager.Instance.profileList[2];
                    GameManager.Instance.volume.profile = GameManager.Instance.currentProfile;

                    if (hit.collider.CompareTag("Player"))
                    {
                        MapManager.Instance.isNotan = false;
                        StateMachineController.instance.ChangeTo<ColorsState>();
                        //ShowOnColors.Instance.Setup();
                        MapManager.Instance.ToColor();
                    }
                }
            }
            
            if (touch.phase == TouchPhase.Moved){                
                pos = Camera.main.ScreenToWorldPoint(touch.position);
                pos.z = 0;
                int layerMask = 1<<8;
                RaycastHit2D hit2D = Physics2D.Linecast(PlayerController.instance.transform.position, pos,  layerMask);
                if(hit2D.collider != null){
                    Debug.DrawLine(PlayerController.instance.transform.position, pos,Color.green,2f);
                    Debug.Log("Hit CHIARO");
                    hit2D.collider.gameObject.transform.position = pos;
                }
                else{
                    Debug.DrawLine(PlayerController.instance.transform.position, pos,Color.red,2f);
                    Debug.Log("Missed");
                }
            }
        }
    }
}