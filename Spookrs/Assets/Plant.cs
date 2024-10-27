using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Plant : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector3Int position;
    public Tile pumpkinTile;
    public Camera MainCam;

    [ContextMenu("PlantItem")]
    void PlantItem(Vector3Int plantPoint){
        tilemap.SetTile(plantPoint, pumpkinTile);
    }

    void OnMouseDown(){
        Vector3 mousePos = Input.mousePosition;
        Vector3 plantPoint = MainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10)); // z value set to 10 since for some reason this function takes 10 off the value
        PlantItem(Vector3Int.FloorToInt(plantPoint));
    }
}