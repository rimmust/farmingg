using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InventoryPButton : MonoBehaviour
{
    [SerializeField] GameObject panel;
    // Start is called before the first frame update

    //sounds
    [SerializeField] AudioClip ClickSound;
    
    //open panel
    public void Openpanel()
    {
        if (panel != null)
        {
            //play sound
            AudioSource.PlayClipAtPoint(ClickSound, Camera.main.transform.position);
            bool opened = panel.activeSelf;
            panel.SetActive(!opened);
            //  panel.SetActive(true);
        }
     
        
    }
}
