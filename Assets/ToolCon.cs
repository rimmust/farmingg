using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;


public class ToolCon : MonoBehaviour
{
    
    //serailized filed to  Marker manager
    [SerializeField]  MarkersM markerM;
    [SerializeField] TileMapReadController tileMapReadController;
    [SerializeField] CropsManager cropsManager;
    [SerializeField]  TileInfo plowableTiles;
    
    [SerializeField]  PlowableTile onTilePickUp;
    
    [SerializeField]  ItemHolder _itemHolder;

    Vector3Int chosenTilePosition;
    private TileBase chosenTile;
    private bool selected;
    
    
    //sounds
    [SerializeField] AudioClip CropSound;
    
    //sounds
    [SerializeField] AudioClip PlowSound;

    private void Update()
    {
        ChoseTile();
        Check();
        Marker();
        UseToolGrid();
    }

    private void ChoseTile()
    {
        chosenTilePosition = tileMapReadController.GetCellPosition(Input.mousePosition,true);
        chosenTilePosition.z = 0; // layer qed johrog -10 minhabba l-camera, u qed inbiddluh ghal 0 biex jaqbel mat-tilemap
        
        chosenTile = tileMapReadController.GetTileB(chosenTilePosition);
        selected = chosenTile != null && chosenTile is PlowableTile;
    }

    void Check()
    {
        markerM.Show(selected);
    }
    private void Marker()
    {
      
       markerM.markerPosition = chosenTilePosition;
        
    }


    //This method chekcs if the tile can be plow and if it is plowed then can be seeeded.s
    private void UseToolGrid()
    {
        if (selected == true)
        {
            // when I click
            if (Input.GetMouseButtonDown(0))
            {
                if (chosenTile is PlowableTile plowableTile)
                {
                    if (plowableTile.isPlowed == false)
                    {
                        Debug.Log("i am plowed");
                        //play sound
                        AudioSource.PlayClipAtPoint(PlowSound, Camera.main.transform.position);
                        tileMapReadController.SetTile(chosenTilePosition, plowableTile.plowedTile);
                        return;
                    }

                    
                    var crop = cropsManager.GetCropAtPosition(chosenTilePosition);
                    if (crop is { CanHarvest: true })
                    {
                        cropsManager.RemoveSeed(chosenTilePosition);
                        tileMapReadController.SetTile(chosenTilePosition, plowableTile.plowedTile);
                        
                        // Add the crop to the inventory
                        AddToInventory(crop.yieldCrop, _itemHolder); // null has to be the inventory
                        return;
                    }
                }
                
                
                //check if tile plowed or not already
                if (cropsManager.Check(chosenTilePosition) == false)
                {
                    //play sound
                    if (cropsManager.Seed(chosenTilePosition))
                    {
                        AudioSource.PlayClipAtPoint(CropSound, Camera.main.transform.position);
                    }
                }
                
            }
            
        }

      //  PickUpTile();


    }
    
    //add the after harvest to the inventory
    //calls the methid from the invenotry and increment the count.
    public  void AddToInventory(Itemtos itemToAdd, ItemHolder inventory)
    {
        inventory.AddToInventoryCount(itemToAdd);
    }

  // private void PickUpTile()
   //{
     //  if (onTilePickUp == null) {return;}

       //{
         //  onTilePickUp.onApplyToTileMap(chosenTilePosition, tileMapReadController, null);
       //}
   //}
    
}
