using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] Tilemap passableTilemap;

    int tiles;

    List<TileNode> open = new List<TileNode>(); //the set of nodes to be evaluated
    List<TileNode> closed = new List<TileNode>(); //the set of nodes already evaluated

    void Start()
    {
        //searches for amount of all boundary tiles
        BoundsInt bounds = passableTilemap.cellBounds;
        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            Tile tile = passableTilemap.GetTile<Tile>(pos);

            if (tile != null )
            {
                tiles++;
            }
        }

        // adds the starting node to "open"
        Vector3Int enemyPos = Vector3Int.FloorToInt(gameObject.transform.position);
        TileNode enemyNode = new TileNode(true, enemyPos);
        open.Add(enemyNode);
    }

    void FindPath()
    {
        
    }
}
