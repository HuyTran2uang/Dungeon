using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace FrankUnity.Pathfinding
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] Tilemap _tilemap;
        Vector2Int _mapSize;
        Node[,] _grid;
        [SerializeField] Transform _bottomLeftPoint;

        private void Awake()
        {
            _mapSize = new Vector2Int(_tilemap.size.x, _tilemap.size.y);
            CreateGrid();
        }

        private void CreateGrid()
        {
            _grid = new Node[_mapSize.x, _mapSize.y];
            for (int x = 0; x < _mapSize.x; x++)
            {
                for (int y = 0; y < _mapSize.y; y++)
                {
                    Vector2Int coordinate = new Vector2Int(x, y);
                    Vector3Int cellPos = new Vector3Int(Mathf.RoundToInt(
                        coordinate.x * _bottomLeftPoint.position.x),
                        Mathf.RoundToInt(coordinate.y * _bottomLeftPoint.position.y),
                        0);
                    bool walkable = _tilemap.GetTile(cellPos) != null;
                    Vector2 center = _tilemap.GetCellCenterWorld(cellPos);
                    _grid[x, y] = new Node(walkable, coordinate, center);
                }
            }
        }

        public IEnumerable<Node> GetNeightbourNodes(Node node)
        {
            if(node.Coordinate.x - 1 >= 0)
                yield return _grid[node.Coordinate.x - 1, node.Coordinate.y];
            if (node.Coordinate.y - 1 >= 0)
                yield return _grid[node.Coordinate.x, node.Coordinate.y - 1];
            if (node.Coordinate.x + 1 < _mapSize.x)
                yield return _grid[node.Coordinate.x + 1, node.Coordinate.y];
            if (node.Coordinate.y < _mapSize.y)
                yield return _grid[node.Coordinate.x, node.Coordinate.y + 1];
        }

        public Node GetNodeFrom(Vector3 worldPosition)
        {
            return _grid[Mathf.RoundToInt(worldPosition.x), Mathf.RoundToInt(worldPosition.y)];
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(_bottomLeftPoint.position - Vector3.one * .5f + new Vector3(_mapSize.x / 2f, _mapSize.y / 2f, 0), new Vector3(_mapSize.x, _mapSize.y, 0));

            for (int x = 0; x < _mapSize.x; x++)
            {
                for (int y = 0; y < _mapSize.y; y++)
                {
                    if (_grid[x, y].Walkable)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawCube(_bottomLeftPoint.position - Vector3.one * .5f + new Vector3(x / 2f, y / 2f, 0), new Vector3(1, 1, 0));
                    }
                }
            }
        }
    }
}
