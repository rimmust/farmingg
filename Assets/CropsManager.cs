using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class CropsManager : TimeA
{
    //declare for tile map
    [SerializeField] private TileBase plowed;
    [SerializeField] private CropTile seeded;
    [SerializeField] private Tilemap hoverTilemap;

    //add a sprite prefab
    [SerializeField] GameObject cropsSpritePrefab;

    //dictonary of crops
    private Dictionary<Vector3Int, Crop> crops = new();

    protected override void Start()
    {
        //if removed crops dont get added 
        //call dealegate of time agent
        onTimeChangeT += Tick;
        base.Start();
    }

    //22/5/25
    //tick method to count
    public void Tick()
    {
        // we cannot change the dictionary directly in a loop,
        // so we need to copy the tile positions in a different array
        var positions = crops.Keys.ToArray();
        //iterate each hour for the crop tile
        foreach (var position in positions)
        {
            var crop = crops[position];
            //if null skip this iteration 
            if (crop == null)
            {
                continue;
            }

            //if timer is bigger than growth time
            if (crop.growTimer >= crop.timeToGrow && crop.timeToGrow > 0)
            {
                hoverTilemap.SetTile(position, crop.next);
                crops[position] = crop.next.CreateCrop();
                continue;
            }

            crop.growTimer += 1;
        }
    }

    //check if can seed
    public bool Check(Vector3Int position)
    {
        return crops.ContainsKey(position);

    }


    // public void Plow(Vector3Int position)
    // {
    //     if (crops.ContainsKey(position))
    //     {
    //         return;
    //     }
    //     CreatePTile(position);
    // }

    //seed accepts postion
    public bool Seed(Vector3Int position) //Crop toSeed
    {
        if (seeded == null)
            return false;

        hoverTilemap.SetTile(position, seeded);
        crops[position] = seeded.CreateCrop();

        return true;
        //22/05/25
        //what we are seeding to the tile
        // crops[(Vector2Int)position].crop = toSeed;


    }

    public void RemoveSeed(Vector3Int position)
    {
        hoverTilemap.SetTile(position, null);
        crops.Remove(position);
    }


    // private void CreatePTile(Vector3Int position)
    // {
    //     //add instance to dictionary 
    //     crops.Add(position,crop);
    //     
    //     hoverTilemap.SetTile(position,plowed);
    //     
    //  
    //     //the code for the prefab
    //     GameObject go = Instantiate(cropsSpritePrefab);
    //     go.transform.position = hoverTilemap.CellToWorld(position);
    //     go.SetActive(false);
    //     crop.renderer = go.GetComponent<SpriteRenderer>();
    //     
    // }

    public void SetCropTile(CropTile cropTile)
    {
        seeded = cropTile;
    }

    public void ClearCropTile()
    {
        seeded = null;
    }

    public Crop GetCropAtPosition(Vector3Int position)
    {
        //if there is no crop it will return unull
        return crops.GetValueOrDefault(position);
    }

}
