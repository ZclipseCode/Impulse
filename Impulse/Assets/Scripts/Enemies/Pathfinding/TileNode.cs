using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNode
{
    public bool walkable;
    public Vector3 pos;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;
    public TileNode parent;

    public TileNode(bool walkable, Vector3 pos, int gridX, int gridY)
    {
        //this.gCost = gCost;
        //this.hCost = hCost;
        //this.pos = pos;

        //fCost = this.gCost + this.hCost;

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

    //public override string ToString()
    //{
    //    return $"G cost = {gCost}, H cost = {hCost}, F cost = {fCost}, position = {pos}";
    //}
}
