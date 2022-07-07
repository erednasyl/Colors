using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    public bool isNotan = false;

    [SerializeField]
    public Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    public Dictionary<TileBase, TileData> dataFromTiles;

    //
    public Vector3Int minXY;
    public Vector3Int maxXY;
    public List<Vector3Int> tiles;
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

    public List<Vector3Int> LoadTiles(){
        List<Vector3Int> tiles = new List<Vector3Int>();
        for (int i = minXY.x; i <= maxXY.x; i++){
            for (int j = minXY.y; j <= maxXY.y; j++){
                Vector3Int currentPos = new Vector3Int(i, j, 0);
                if (map.HasTile(currentPos)){
                    tiles.Add(currentPos);
                }
            }
        }
        Debug.Log("FORAM CRIADOS " + tiles.Count + "TILES" );
        return tiles;
    }

    void Update(){
        //Tiles clicáveis
        if (isNotan){
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    Vector3Int gridPosition = map.WorldToCell(touchPosition);

                    TileBase clickedTile = map.GetTile(gridPosition);
                    Debug.Log(gridPosition);
                    
                    if (clickedTile != null)
                    {
                        TileBase nextTile = MapManager.Instance.dataFromTiles[clickedTile].nextTile;
                        map.SetTile(gridPosition, nextTile);
                    }
                }
            }
        }
    }
}
