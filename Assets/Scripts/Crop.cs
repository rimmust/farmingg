public class Crop
{
    // 22/05/25  these should go there
    //scripatble object Crop
    public int timeToGrow = 10;

    //reference what will grow
    public Itemtos yieldCrop;

    //defalut value of 1
    public int growTimer = 0;
    public CropTile next;

    public bool CanHarvest => yieldCrop != null && growTimer >= timeToGrow;
}