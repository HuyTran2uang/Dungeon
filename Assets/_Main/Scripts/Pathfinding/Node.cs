using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrankUnity.Pathfinding
{
    public class Node
    {
        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost => GCost + HCost;

        public bool Walkable { get; }
        public Vector2Int Coordinate { get; }
        public Vector2 Center { get; }

        public Node(bool walkable, Vector2Int coordinate, Vector2 center)
        {
            Walkable = walkable;
            Coordinate = coordinate;
            Center = center;
        }
    }
}
