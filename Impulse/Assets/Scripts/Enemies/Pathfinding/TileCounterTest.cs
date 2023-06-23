using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileCounterTest : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    int totalTiles;

    void Start()
    {
        BoundsInt bounds = tilemap.cellBounds;
        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            Tile tile = tilemap.GetTile<Tile>(pos);

            if (tile != null)
            {
                totalTiles++;
            }
        }

        Debug.Log(totalTiles);
    }
}
