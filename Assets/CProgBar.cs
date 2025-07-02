using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CProgBar : MonoBehaviour
{
    public Slider progressBar;
    public int cropsHarvested = 0;
    public int totalCropsNeeded = 20;

    //show text as progress bar is full
    [SerializeField] TextMeshProUGUI LevelText;
    
    public void HarvestCrops()
    {
        cropsHarvested++;
        progressBar.value = cropsHarvested;
        
        if(cropsHarvested >= totalCropsNeeded)
        {
            Debug.Log("Level up");

            //Reset progress bar as level up
            cropsHarvested = 0;
            progressBar.value = 0;
            
            //message
            StartCoroutine(ShowProgressLevel());
        }
    }
    
    //show the message level up on screen
    IEnumerator ShowProgressLevel()
    {
        LevelText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        LevelText.gameObject.SetActive(false);
    }
    

}
