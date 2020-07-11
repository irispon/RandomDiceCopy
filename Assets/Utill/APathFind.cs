using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APathFind : MonoBehaviour
{     
    /*
    IEnumerator FindPath(Vector2 startPos, Vector2 targetPos)
    {

   
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);
        bool pathSuccess = false;
        if (startNode.walkable && targetNode.walkable)
        {
            List openSet = new List();
            HashSet closedSet = new HashSet();
            openSet.Add(startNode);
            while (openSet.Count > 0)
            {
                Node currentNode = openSet[0];
                for (int i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                    {
                        currentNode = openSet[i];
                    }

                }
                openSet.Remove(currentNode);
                closedSet.Add(currentNode);
                if (currentNode == targetNode)
                {
                    if (pathSuccess == false)
                    {
                        PushWay(RetracePath(startNode, targetNode));

                    }
                    pathSuccess = true;
                    break;
                }
                foreach (Node neighbour in grid.GetNeighbours(currentNode))
                {
                    if (!neighbour.walkable || closedSet.Contains(neighbour))
                        continue;
                    int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                    if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = newMovementCostToNeighbour;
                        neighbour.hCost = GetDistance(neighbour, targetNode);
                        neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                    }
                }
            }
        }
    }

    Vector2[] RetracePath(Node startNode, Node endNode)
    {
        List path = new List();
        Node currentNode = endNode;
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();
        grid.path = path;

        Vector2[] wayPoints = SimplifyPath(path);
        return wayPoints;

    }

    Vector2[] SimplifyPath(List path)
    {
        List wayPoints = new List();

        for (int i = 0; i < path.Count; i++)
        {
            wayPoints.Add(path[i].worldPosition);
        }
        return wayPoints.ToArray();
    }

    */
}
