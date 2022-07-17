using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.Experimental.Rendering.Universal;

public class ChangeColors : MonoBehaviour
{
    public static ChangeColors Instance;

    void Awake(){
        Instance = this;
    }

    public void ToNotan(){
        //set lights
        GameManager.Instance.main.backgroundColor = Color.black;

        GameManager.Instance.globalLight.color = new Color(0.91509403f, 0.9039948f, 0.876246f, 1);
        foreach (GameObject light in GameManager.Instance.pointLights)
        {
            light.GetComponent<Light2D>().intensity = 1f;
            light.SetActive(false);
        }

        //set tiles to black
        foreach (var tilePos in MapManager.Instance.tiles){
            TileBase currTile = MapManager.Instance.map.GetTile(tilePos);

            TileBase realTile = MapManager.Instance.dataFromTiles[currTile].realTile;
            MapManager.Instance.map.SetTile(tilePos, realTile);
        }
    }

    public void ToColor(){
        //set camera color
        GameManager.Instance.main.backgroundColor = new Color(0.6759078f, 0.7830189f, 0.7758349f, 1);

        //set global light
        GameManager.Instance.globalLight.color = new Color(0.8415806f, 0.8768347f, 0.913f, 1);

        foreach (GameObject light in GameManager.Instance.pointLights)
        {
            light.GetComponent<Light2D>().intensity = 0.2f;
        }

        //set tiles to color
        foreach (var tilePos in MapManager.Instance.tiles){
            TileBase currTile = MapManager.Instance.map.GetTile(tilePos);

            TileBase realTile = MapManager.Instance.dataFromTiles[currTile].realTile;
            MapManager.Instance.map.SetTile(tilePos, realTile);
        }
    }

    public void ToChiao(){
        GameManager.Instance.globalLight.color = Color.black;
        foreach (GameObject light in GameManager.Instance.pointLights)
        {
            light.SetActive(true);
        }
    }
}
