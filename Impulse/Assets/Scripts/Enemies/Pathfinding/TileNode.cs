using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNode
{
    //public int gCost;
    //public int hCost;
    //public int fCost;
    public bool walkable;
    public Vector3 pos;

    public TileNode(bool walkable, Vector3 pos)
    {
        //this.gCost = gCost;
        //this.hCost = hCost;
        //this.pos = pos;

        //fCost = this.gCost + this.hCost;

        this.walkable = walkable;
        this.pos = pos;
    }

    //public override string ToString()
    //{
    //    return $"G cost = {gCost}, H cost = {hCost}, F cost = {fCost}, position = {pos}";
    //}
}
