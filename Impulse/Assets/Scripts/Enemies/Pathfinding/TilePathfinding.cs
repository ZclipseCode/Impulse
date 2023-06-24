using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TilePathfinding : MonoBehaviour
{
    TileGrid grid;
    Vector3 nextPos;

    private void Awake()
    {
        grid = GameObject.FindGameObjectWithTag("Pathfinding").GetComponent<TileGrid>();
    }

    public void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        TileNode startNode = grid.NodeFromWorldPoint(startPos);
        TileNode targetNode = grid.NodeFromWorldPoint(targetPos);

        Heap<TileNode> openSet = new Heap<TileNode>(grid.MaxSize);
        HashSet<TileNode> closedSet = new HashSet<TileNode>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            TileNode currentNode = openSet.RemoveFirst();
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (TileNode neighbor in grid.GetNeighbors(currentNode))
            {
                if (!neighbor.walkable || closedSet.Contains(neighbor))
                {
                    continue;
                }

                int newMovementCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor);
                if (newMovementCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newMovementCostToNeighbor;
                    neighbor.hCost = GetDistance(neighbor, targetNode);
                    neighbor.parent = currentNode;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }
    }

    void RetracePath(TileNode startNode, TileNode endNode)
    {
        List<TileNode> path = new List<TileNode>();
        TileNode currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;

        if (path.Count >= 1)
        {
            //nextPos = new Vector3(path[1].gridX, path[1].gridY);
            nextPos = path[0].pos;
        }
    }

    int GetDistance(TileNode nodeA, TileNode nodeB)
    {
        int disX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int disY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (disX > disY)
        {
            return 14 * disY + 10 * (disX - disY);
        }
        return 14 * disX + 10 * (disY - disX);
    }

    public Vector3 GetNextPos()
    {
        return nextPos;
    }
}
