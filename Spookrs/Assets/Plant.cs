using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{
    [SerializeField]
    private TileData[] tileDatas;

    [SerializeField]
    private Dictionary<Tile, bool> plantableTiles = new Dictionary<Tile, bool>();

    public Tilemap tilemap;
    public Vector3Int position;
    public Tile pumpkinTile;
    public Camera MainCam;

    void Awake(){
        foreach (TileData tileData in tileDatas)
        {
            foreach (Tile tile in tileData.tiles)
            {
                plantableTiles.Add(tile, tileData.plantable);
            }
        }
    }


    [ContextMenu("PlantItem")]
    void PlantItem(Vector3Int plantPoint){
        Tile clickedTile = tilemap.GetTile<Tile>(plantPoint);
        if (plantableTiles.ContainsKey(clickedTile))
        {
            tilemap.SetTile(plantPoint, pumpkinTile);
        }
    }

    void OnMouseDown(){
        Vector3 mousePos = Input.mousePosition;
        Vector3 plantPoint = MainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10)); // z value set to 10 since for some reason this function takes 10 off the value
        PlantItem(tilemap.WorldToCell(plantPoint));
    }
}