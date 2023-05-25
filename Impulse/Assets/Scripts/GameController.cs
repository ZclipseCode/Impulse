using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] States initialState = States.MENU;
    public static States gameState;

    int enemyTurns;

    public delegate void EnemyTurnHandler();
    public static EnemyTurnHandler enemyTurnHandler;

    private void Awake()
    {
        gameState = initialState;

        enemyTurnHandler += AddEnemyTurn;
    }

    private void Update()
    {
        
    }

    private void AddEnemyTurn()
    {
        enemyTurns++;
        Debug.Log(enemyTurns);
    }

    private void OnDestroy()
    {
        enemyTurnHandler -= AddEnemyTurn;
    }
}
