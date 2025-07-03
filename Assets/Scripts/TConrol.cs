using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TConrol : MonoBehaviour
{
    const  float secondsInDay = 86400f;
    
    //time agents code 15minutes in sec
    private const float phaseLenght = 900f;
    
    private int days;
    
    
    //colors 3/7/25
    [SerializeField] Color nightLColor;
    [SerializeField] AnimationCurve  nightTCurve;
    [SerializeField] Color dayLightLColor  =Color.white;
    
    [SerializeField] Light2D globalLight2D;
    
    //21/05/25
    //list of the agents 
    List<TimeA> agents;

    //not needed
   // private void Start()
    //{
     //   time = startTime;
   // }
   // [SerializeField] float startTime = 28800f;
    
    //initate the list on the awake method
    private void Awake()
    {
        agents = new List<TimeA>();
    }
    
    
    public void Subscribe(TimeA timeAgent)
    {
        agents.Add(timeAgent);
    }
    

    public void Unsubscribe(TimeA timeAgent)
    {
        agents.Remove(timeAgent);
    }
    
    
    float time;
    
    [SerializeField] float timescale = 60f;
    
    //create the text
    [SerializeField]  TextMeshProUGUI text;

    
    float Hours
    {
        get{return time/3600f; }
    }
    
    float Minutes 
    {
        get{return time % 3600f /60f; }
    }

    private void Update()
    {
        time += Time.deltaTime * timescale;
     
        //post timer on screen
       // int hh = (int)Hours;
        //int mm = (int)Minutes;
        //text.text = $"{hh:00}:{mm:00}";
        TimeCalculation();
        if(time > secondsInDay)
        {
            NextDay();
        }

        TimeAgents();
        
        //colors 3/7/25
        float v = nightTCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightLColor, nightLColor, v);
        globalLight2D.color = c;
        
    }
    
    private void NextDay()
    {

        time = 0;
        days += 1;
    }

    private void TimeCalculation()
    {
        //post timer on screen
        text.text = $"{Hours:00}:{Minutes:00}";
    }

    private int prevoPhase = 0;
    
    private void TimeAgents()
    {
        //divide the time in phase lenght
        int cuphase = (int)(time/phaseLenght);
      
      
        //compare old phase with current phase and invoke all phases
        if (prevoPhase != cuphase)
        {
            prevoPhase = cuphase;
            
            //invoke the timetick deligate 
            for (int i = 0; i < agents.Count; i++)
            {
                agents[i].Invoke();
            }  
            
        
            
        }
        
    }

}
