using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrankUnity.Pathfinding
{
    public class Pathfinding
    {
        public void FindPath(Node startNode, Node targetNode)
        {
            List<Node> openSet = new List<Node>();
            HashSet<Node> closedSet = new HashSet<Node>();
            openSet.Add(startNode);
            Node currentNode = openSet[0];
            while (true)
            {
                //set current node
                foreach (var node in openSet)
                {
                    if(node.FCost < currentNode.FCost && node.HCost < currentNode.HCost)
                    {
                        currentNode = node;
                    }
                }
            }
        }
    }
}
