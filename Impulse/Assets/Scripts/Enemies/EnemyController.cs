using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void Awake()
    {
        GameController.enemyTurnHandler += EndTurn;
    }

    private void Start()
    {
        //GameController.enemyTurnHandler?.Invoke();
        GameController.enemyHandler?.Invoke();
    }

    private void EndTurn()
    {
        Debug.Log("turn ended");
    }

    private void OnDestroy()
    {
        GameController.enemyTurnHandler -= EndTurn;
    }
}
