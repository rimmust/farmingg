using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ItemSlot
{
    public  Itemtos  item;
    public int count;
}
[CreateAssetMenu(menuName = "Data/ItemHolder")]
public class ItemHolder : ScriptableObject
{
    public List<ItemSlot> slots;
    
    //add the item to the inventory once harvested 
    //add the parameter
    public void AddItem(Itemtos item, int count = 1)
    {
        //determine is this new item and stackable 
        //find empty slot an dput it in the slot
     
        if (item.avaible == true)
        {
            //if we have 1 add the count to the slot 
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if (itemSlot != null)
            {
                itemSlot.count += count;
            }
            //add  a new item to the slot not needed
        }
        else
        {
            //add a new item to the itemholder 
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (itemSlot == null)
            {
                itemSlot.item = item;

            }
        }
    }
    
    //21/05/25
    //Update the inventory after harvest fruit or vegetable
    public void AddToInventoryCount(Itemtos itemToAdd, int count = 1)
    {
        //if it is avalibe find the slot which contains this item
        if (itemToAdd.avaible)
        {
         ItemSlot itemSlot = slots.Find(x => x.item == itemToAdd);
         if (itemSlot == null)
         { return; }

         itemSlot.count += count;
         Debug.Log("inventory added by 1");
        }
        
    }
    
    
}
