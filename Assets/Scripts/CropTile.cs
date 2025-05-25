using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Data/CropTile")]
public class CropTile : Tile
{
    //[Tooltip("If this is the final tile, set to -1.")]
    public int timeToGrow = 10;
    public CropTile next;
    public Itemtos yieldCrop;

    public Crop CreateCrop()
    {
        return new Crop
        {
            timeToGrow = timeToGrow,
            yieldCrop = yieldCrop,
            next = next
        };
    }
}

