using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeA : MonoBehaviour
{
    //21/05/25
    
    //deligate 
    public Action onTimeChangeT;
    
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        //subscribe time agent to the TControl
        //GameManager.instance.timeControl.Subscribe(this);
       Init();
    }

    public void Init()
    {
        Debug.Log(GameManager.instance.timeControl);
      //  subscribe time agent to the TControl
       GameManager.instance.timeControl.Subscribe(this);
    }
    
    //tells the time agents that time had passed
    public void Invoke()
    {
        onTimeChangeT?.Invoke();
    }

    private void OnDestroy()
    {
        GameManager.instance.timeControl.Unsubscribe(this);
    }
   
}
