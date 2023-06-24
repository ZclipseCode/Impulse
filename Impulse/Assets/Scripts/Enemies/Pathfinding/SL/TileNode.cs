using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNode : IHeapItem<TileNode>
{
    public bool walkable;
    public Vector3 pos;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public TileNode parent;
    int heapIndex;

    public TileNode(bool walkable, Vector3 pos, int gridX, int gridY)
    {
        this.walkable = walkable;
        this.pos = pos;
        this.gridX = gridX;
        this.gridY = gridY;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }
        set
        {
            heapIndex = value;
        }
    }

    public int CompareTo(TileNode nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if (compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return -compare;
    }
}
