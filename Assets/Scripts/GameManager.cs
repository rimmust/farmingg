using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }


    private void Awake()
    {
        if (instance == null) //so that the game mangers if there is more than 1 they dont fight 
        {
            //here we show that as the game loads this is the instacne of this manager
            instance = this;
        }
    }
    //The instance of the inventory holder
    public ItemHolder inventoryholder;
    
    
    //21/05/25
    public TConrol  timeControl;
    
    //start the game
    public static GameState State { get; private set; } = GameState.Welcome;

    [Header("Screens")] [SerializeField] private GameObject welUI;
    [SerializeField] private GameObject instUI;
    [SerializeField] private GameObject gameplayUI;
    
   
    // Start is called before the first frame update
    void Start()
    {
        //show welcome screen

        ChangeStateofGame(GameState.Welcome);
    }
    
    
    //this method declare each staete
    public void ChangeStateofGame(GameState newState)
    {
        welUI?.SetActive(newState == GameState.Welcome);
        instUI?.SetActive(newState == GameState.Instuctions);
        gameplayUI?.SetActive(newState == GameState.Playing);

        State = newState;

    }

    //change states
    public void ChangeStatetoPlaying()
    {

        ChangeStateofGame(GameState.Playing);


    }

    public void ChangeStatetoWelcome()
    {
        ChangeStateofGame(GameState.Welcome);
    }

    public void ChangeStatetoInstructions()
    {
        ChangeStateofGame(GameState.Instuctions);
    }




}
