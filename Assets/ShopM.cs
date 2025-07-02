using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopM : MonoBehaviour
{
    //set uo the array
    public int[,] shopItems = new int[5,5];
    
    //the coins
    public float coins;
    
    //the text
    public TextMeshProUGUI CoinsTxt;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        CoinsTxt.text = "Coins: " + coins.ToString();
        
        //intialise the array
        //set the colom 1 and star with 1
        //colom 1 is the id the other is quantity
        //we have 4 items
        
        //IDs
        shopItems[1,1] = 1;
        shopItems[1,2] = 2;
        shopItems[1,3] = 3;
        shopItems[1,4] = 4;
        
        //price
        shopItems[2,1] = 10;
        shopItems[2,2] = 20;
        shopItems[2,3] = 30;
        shopItems[2,4] = 40;
        
        //Quantity
        shopItems[3,1] = 0;
        shopItems[3,2] = 0;
        shopItems[3,3] = 0;
        shopItems[3,4] = 0;
        
        
    }

    public void BuyItem()
    {
        //refernce the button 
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>()
            .currentSelectedGameObject;
        
        //check if we have coins to buy the item
        if (coins >= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            //subtract the price
            coins -= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsTxt.text = "Coins: " + coins.ToString();
            //update the quantity button text 
            ButtonRef.GetComponent<ButtonInfo>().QuantityText.text =  shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();

        }
    }
}
