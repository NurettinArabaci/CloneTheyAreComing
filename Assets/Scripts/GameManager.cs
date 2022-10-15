using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Begin,
    Play,
    Lose,
    Win
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState gameState;

    private void Awake()
    {
        Instance = this;
        gameState = GameState.Begin;
    }

    public void StopMovement()
    {

        PlayerController.speed = 0;
        PlayerController.limitX = 0;
        
    }

   public void StartMovement()
    {
        PlayerController.speed = 10;
        PlayerController.limitX = 11;
        gameState = GameState.Play;
    }

    
}
