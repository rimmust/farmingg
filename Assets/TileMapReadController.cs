using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapReadController : MonoBehaviour
{
    //conveert world point to grid positon
    [SerializeField] Tilemap tilemap;
    
    //the dictoanry of tile data
    [SerializeField]  List<TileInfo> tileInfo;

    Dictionary<TileBase, TileInfo> dataFromTiles = new();

    private void Start()
    {
        dataFromTiles = new Dictionary<TileBase, TileInfo>();
        foreach (TileInfo tileInfo in tileInfo)
        {
            foreach (TileBase tile in tileInfo.tiles)
            {
                dataFromTiles.Add(tile, tileInfo);
            }
        }
        
    }
    
    
    //sepearet all the methods
    
    public Vector3Int GetCellPosition(Vector2 position,bool mousePosition)
    {
        Vector3 wPosition;
        
        if (mousePosition)
        {
            wPosition=Camera.main.ScreenToWorldPoint(position);
        }

        else
        {
            wPosition = position;
        }
     
      
        //comvert world position to cell position
        Vector3Int cellPosition = tilemap.WorldToCell(wPosition);

        return cellPosition;
    }
    
    //gets the tile data 

    public TileBase GetTileB(Vector3Int cellPosition,bool mousePosition = false)
    {
        
        //Debug.Log("tile in postion" + cellPosition +"is" + tile);
        return tilemap.GetTile(cellPosition);
        
    }
    
    //get the tildata
    public TileInfo GetTileInfoD(TileBase tileb)

    {
        return dataFromTiles[tileb];
    }

    public void SetTile(Vector3Int position, TileBase newTile)
    {
        tilemap.SetTile(position, newTile);
    }
}
