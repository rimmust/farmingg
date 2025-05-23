using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToolBarController : MonoBehaviour
{
    
    //toolbar size
    [SerializeField] private int toolbarAmount = 8;
    //used tool
    int ChoosenTool ;
    
    
    //scrool between slots on toolbar
    private void Update()
    {
        // float delta = Input.mouseScrollDelta.y;
        // if (delta != 0)
        // {
        //     if (delta > 0)
        //     {
        //         ChoosenTool += 1;
        //         ChoosenTool = (ChoosenTool >= toolbarAmount ? 0 : ChoosenTool);
        //     }
        //     else
        //     {
        //         ChoosenTool += 1;
        //         ChoosenTool = (ChoosenTool <= 0 ? toolbarAmount -1 : ChoosenTool);
        //     }
        //     Debug.Log(ChoosenTool);
        // }
        //
    }

    internal void Set(int index)
    {
        ChoosenTool = index;
    }
    
}
