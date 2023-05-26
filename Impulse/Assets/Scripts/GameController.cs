using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] States initialState = States.MENU;
    public static States gameState;

    public delegate void EnemyTurnHandler();
    public static EnemyTurnHandler enemyTurnHandler;

    public delegate void PlayerTurnHandler();
    public static PlayerTurnHandler playerTurnHandler;

    public delegate void EnemyHandler();
    public static EnemyHandler enemyHandler;

    [SerializeField] int enemies = 0;
    [SerializeField] int enemyTurns = 0;

    private void Awake()
    {
        gameState = initialState;

        enemyTurnHandler += CheckEnemyTurns;

        playerTurnHandler += PlayerTurnEnded;

        enemyHandler += EnemyAdded;
    }

    private void Update()
    {
        
    }

    private void CheckEnemyTurns()
    {
        if (enemyTurns <= 0)
        {
            gameState = States.PLAYER;
        }
        else
        {
            //enemyTurns--;
            gameState = States.ENEMIES;
        }
    }

    private void PlayerTurnEnded()
    {
        //gameState = States.ENEMIES;
        enemyTurns = enemies;
        CheckEnemyTurns();
    }

    private void EnemyAdded()
    {
        enemies++;
    }

    private void OnDestroy()
    {
        enemyTurnHandler -= CheckEnemyTurns;

        playerTurnHandler -= PlayerTurnEnded;

        enemyHandler -= EnemyAdded;
    }
}
