using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;

public class InveButton : MonoBehaviour
{
 //2 serialized reference to the image and text
 [SerializeField] Image image; //icon
 [SerializeField] TextMeshProUGUI text;

 private int mIndex;

 public void SetIndex(int index)
 {
  mIndex = index;
  
 }

 //set the item as a paramater
 public void Set(ItemSlot slot)
 {
  
  image.gameObject.SetActive(true);
  //set up the item to show on screen
  image.sprite = slot.item.icon;
  
  //checke if the item is avalible
  //set the count to test
  if (slot.item.avaible == true)
  {
   text.gameObject.SetActive(true);
   text.text = slot.count.ToString();
  }
  else
  {
   //hide the item count if it is not stacable 
   text.gameObject.SetActive(false);
  }
 }

 public void Clean()
 {
  image.sprite = null;
  image.gameObject.SetActive(false);
  text.gameObject.SetActive(false);
 }

 public void OnPointerClick(PointerEventData eventData)
 {
  ItemP itemPanel = transform.parent.GetComponent<ItemP>();
  //the button at index is clicked
  itemPanel.OnClick(mIndex);
  
 }
}
