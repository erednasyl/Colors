using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckForFruits : MonoBehaviour
{
    public GameObject toActivate;
    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag("Player"))
        {
            foreach (var map in MapManager.Instance.maps){
                foreach (var tilePos in MapManager.Instance.tiles){                
                    TileBase currTile = map.GetTile(tilePos);
                    if (currTile != null){
                        if(currTile.name == "busto" || currTile.name == "bw2"){
                            GetComponent<DialogueTrigger>().TriggerDialogue();
                            if(toActivate != null)
                                toActivate.SetActive(true);
                            GameManager.Instance.changeScenesTimer = 8f;
                            gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}