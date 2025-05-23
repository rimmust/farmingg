using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/PlowableTile")]
public class PlowableTile : Tile
{
    public PlowableTile plowedTile;
    public bool isPlowed = false;
}