using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemP : MonoBehaviour
{
   //copy the invenotry panel to be used as a base 
   //connect the item slot to the inventorypanel
   public ItemHolder inventory;

   //decalre the button
   public  List<InveButton> buttons;
    
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

   //accept id as a parameter
   public virtual void OnClick( int index ) //int id
   {
      
   }
   
}
