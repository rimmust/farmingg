using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor.Search;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    //connect the item slot to the inventorypanel
    [SerializeField] private ItemHolder inventory;

    //decalre the button
    [SerializeField] private List<InveButton> buttons;
    
    private void Start()
    {
        SetIndex();
        Show();
    }

    

  //  private void OnEnable()
    //{
      //  Show();
    //}

    private void Show()
    {
        //if there is an item show the item if no show nothing
        for (int i = 0; i < inventory.slots.Count &&  i <buttons.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].Clean();
            }
            else
            {
               buttons[i].Set(inventory.slots[i]);
            }
        }
        
    }
    //sets index on the buttons
    private void SetIndex()
    {
        for (int i = 0; i < inventory.slots.Count &&  i <buttons.Count; i++)
        {
           buttons[i].SetIndex(i);
        }
    }
    
    
    
    
}
