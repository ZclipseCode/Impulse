using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void Awake()
    {
        GameController.enemyTurnHandler += AddTurn;
    }

    private void Start()
    {
        GameController.enemyTurnHandler?.Invoke();
    }

    private void AddTurn()
    {
        Debug.Log("added");
    }

    private void OnDestroy()
    {
        GameController.enemyTurnHandler -= AddTurn;
    }
}
