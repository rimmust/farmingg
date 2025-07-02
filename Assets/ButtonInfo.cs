using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
   
    //public ID
    public int ItemID;
    
    //delare the text
    public TextMeshProUGUI PriceText;
    public TextMeshProUGUI QuantityText;
    
    //reference the shopmanager
    public GameObject ShopM;
    
    // Update is called once per frame
    void Update()
    {
        PriceText.text = "Price: $" + ShopM.GetComponent<ShopM>().shopItems[2,ItemID].ToString();
        QuantityText.text = ShopM.GetComponent<ShopM>().shopItems[3,ItemID].ToString();
    }
}
