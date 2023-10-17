using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace FrankUnity.Pathfinding
{
    public class Grid : MonoBehaviour
    {
        Vector2Int _mapSize;
        Node[,] _nodes;
        [SerializeField] Tilemap _tilemap;

        private void Awake()
        {
            _tilemap
        }

        public IEnumerable<Node> GetNeightbourNodes(Node node)
        {
            if(node.Coordinate.x - 1 >= 0)
                yield return _nodes[node.Coordinate.x - 1, node.Coordinate.y];
            if (node.Coordinate.y - 1 >= 0)
                yield return _nodes[node.Coordinate.x, node.Coordinate.y - 1];
            if (node.Coordinate.x + 1 < _mapSize.x)
                yield return _nodes[node.Coordinate.x + 1, node.Coordinate.y];
            if (node.Coordinate.y < _mapSize.y)
                yield return _nodes[node.Coordinate.x, node.Coordinate.y + 1];
        }
    }
}
