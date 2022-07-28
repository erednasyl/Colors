using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.Experimental.Rendering.Universal;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    public bool isNotan = false;

    [SerializeField]
    public List<Tilemap> maps;

    [SerializeField]
    private List<TileData> tileDatas;

    public Dictionary<TileBase, TileData> dataFromTiles;

    //
    public Vector3Int minXY;
    public Vector3Int maxXY;
    public List<Vector3Int> tiles;
    //

    //
    public GameObject enemy;
    public List<Transform> spawnPoints;
    //

    void Awake(){
        Instance = this;
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach(var tileData in tileDatas){
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
        
        tiles = LoadTiles();
    }

    void SpawnEnemies(){
        Instantiate(enemy, spawnPoints[Random.Range(0,5)].transform.position, Quaternion.identity);
    }

    public List<Vector3Int> LoadTiles(){
        List<Vector3Int> tiles = new List<Vector3Int>();
        foreach (var map in maps){
            for (int i = minXY.x; i <= maxXY.x; i++){
                for (int j = minXY.y; j <= maxXY.y; j++){
                    Vector3Int currentPos = new Vector3Int(i, j, 0);
                    if (map.HasTile(currentPos)){
                        tiles.Add(currentPos);
                    }
                }
            }
        }
        Debug.Log("FORAM CRIADOS " + tiles.Count + "TILES" );
        return tiles;
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
        foreach (var map in maps){
        foreach (var tilePos in MapManager.Instance.tiles){
            
            TileBase currTile = map.GetTile(tilePos);

            if (currTile != null)
            {
                TileBase realTile = MapManager.Instance.dataFromTiles[currTile].realTile;
                map.SetTile(tilePos, realTile);                
            }


            }
        }
    }

    public void ToColor(){
        //set camera color
        GameManager.Instance.main.backgroundColor = new Color(0.617f, 0.8768347f, 0.759f, 1);

        //set global light
        GameManager.Instance.globalLight.color = new Color(0.8415806f, 0.8768347f, 0.913f, 1);

        foreach (GameObject light in GameManager.Instance.pointLights)
        {
            light.GetComponent<Light2D>().intensity = 0.2f;
        }
        
        //set tiles to color
        foreach (var map in maps){
            foreach (var tilePos in MapManager.Instance.tiles){
            
            TileBase currTile = map.GetTile(tilePos);
            if (currTile != null){
                TileBase realTile = MapManager.Instance.dataFromTiles[currTile].realTile;
                map.SetTile(tilePos, realTile);}
            }
        }
    }

    public void ToChiao(){
        GameManager.Instance.globalLight.color = Color.black;
        foreach (GameObject light in GameManager.Instance.pointLights)
        {
            light.SetActive(true);
        }


    }

    void Update(){
        //Tiles clicáveis
        if (isNotan){
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    foreach (var map in maps) {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Vector3Int gridPosition = map.WorldToCell(touchPosition);

                    TileBase clickedTile = map.GetTile(gridPosition);
                    Debug.Log(gridPosition);
                    
                    if (clickedTile != null)
                    {
                        TileBase nextTile = MapManager.Instance.dataFromTiles[clickedTile].nextTile;
                        //SpawnEnemies();
                        map.SetTile(gridPosition, nextTile);
                    }}
                }
            }
        }
    }
}
