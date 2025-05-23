using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/TileInfo")]
public class TileInfo : ScriptableObject
{    
    //public array of tile base 
    public List<TileBase>tiles;
    
    //public  bool plowable
    public bool plowable;
    
    
    public bool Evaluate(TileBase tile)
    {
        
        return tile.GetType() == plowable.GetType();
    }
}