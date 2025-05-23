using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemToolBarP : ItemP
{
   
    //reference the tollbar contorller 
    [SerializeField] private ToolBarController _toolBarController;
    //inherit form ItemP
    public override void OnClick(int index)
    {
        //when a button is clicked
        _toolBarController.Set(index);
      // Highlight(index);

    }

  //  private int currentSelectedTool;


    //public void Highlight(int index)
    //{
      //buttons[currentSelectedTool].Highlight(false);
       // currentSelectedTool = index;
        //buttons[currentSelectedTool].Highlight(true);
    //}

}
