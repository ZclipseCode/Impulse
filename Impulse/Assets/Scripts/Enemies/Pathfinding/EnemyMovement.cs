using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    TilePathfinding tilePathfinding;
    Transform target;

    private void Start()
    {
        tilePathfinding = GetComponent<TilePathfinding>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    //testing
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMove();
        }
    }

    void OnMove()
    {
        tilePathfinding.FindPath(transform.position, target.position);
        MoveTo(tilePathfinding.GetNextPos());
        Debug.Log(tilePathfinding.GetNextPos());
    }
}
