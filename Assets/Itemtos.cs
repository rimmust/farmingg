using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Itemtos")]
public class Itemtos : ScriptableObject
{
    //the name of element
    public string itemName;
    public bool avaible; //stackable
    public Sprite icon;

    //21/05/25
   // public ToolCon itemToAdd;
   
   //22/05/25
    public Crop crop;
}
