using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkersM : MonoBehaviour
{
    
    //mark the tile we are hoovering on
    [SerializeField]  Tilemap hooverTilemap;
    [SerializeField] TileBase tile; // issuse
    public  Vector3Int markerPosition;
    Vector3Int lastMarkerPosition;
    bool show;

    private void Update()
    {
        if (show == false) { return;}
        hooverTilemap.SetTile(lastMarkerPosition, null);
        hooverTilemap.SetTile(markerPosition, tile);
        lastMarkerPosition = markerPosition;
    }

    internal void Show(bool selected)
    {
        show = selected;
        hooverTilemap.gameObject.SetActive(show);
       
    }
}
