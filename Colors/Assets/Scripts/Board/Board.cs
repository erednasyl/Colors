using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Dictionary<Vector3Int, TileLogic> tiles; //Iremos perguntar pro dicionário "o que tem nessa posição tal?" e ele retorna o tile.
    public List<Floor> floors;
    public static Board instance;
    [HideInInspector]
    public Grid grid;

    void Awake(){
        tiles = new Dictionary<Vector3Int, TileLogic>();
        instance = this;
        grid = GetComponent<Grid>();
    }

    public IEnumerator InitSequence(LoadState loadState){
        yield return StartCoroutine(LoadFloors(loadState));
        yield return null;
        Debug.Log("Foram criados " + tiles.Count + " tiles");
    }
    
    IEnumerator LoadFloors(LoadState loadState){
        for (int i = 0; i<floors.Count; i++){
            List<Vector3Int> floorTiles = floors[i].LoadTiles();
            yield return null;
            for (int j=0; j<floorTiles.Count; j++){
                if(!tiles.ContainsKey(floorTiles[j])){
                    CreateTile(floorTiles[j], floors[i]);
                }
            }
        }
    }

    void CreateTile(Vector3Int pos, Floor floor){
        Vector3 worldPos = grid.CellToWorld(pos);
        worldPos.y += (floor.tilemap.tileAnchor.y/2) + 2f;
        TileLogic tileLogic = new TileLogic(pos, worldPos, floor);
        tiles.Add(pos, tileLogic);
    }

    public static TileLogic GetTile(Vector3Int pos){
        TileLogic tile = null;
        instance.tiles.TryGetValue(pos, out tile);
        return tile;
    }
}
