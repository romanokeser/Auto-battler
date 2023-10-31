using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Tilemap _grid;

    Graph graph;

    private void Awake()
    {
        InitializeGraph();
    }

    private void InitializeGraph()
    {
        graph = new Graph();

        for (int x = _grid.cellBounds.xMin; x < _grid.cellBounds.xMax; x++)
        {
            for (int y = 0; _grid.cellBounds.yMin < _grid.cellBounds.yMax; y++)
            {
                Vector3Int localPos = new Vector3Int(x, y, (int)_grid.transform.position.y);
                if (_grid.HasTile(localPos))
                {
                    Vector3 worldPos = _grid.CellToWorld(localPos);
                    graph.AddNode(worldPos);
                }
            }
        }

        var allNodes = graph.Nodes;

        foreach (Node from in allNodes)
        {
            foreach (Node to in allNodes)
            {
                if(Vector3.Distance(from.WorldPosition, to.WorldPosition) < 1f && from != to)
                {
                    graph.AddEdge(from, to);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (graph == null)
            return;

        var allEdges = graph.Edges;

        foreach (Edge e in allEdges)
        {
            Debug.DrawLine(e.From.WorldPosition, e.To.WorldPosition, Color.black, 1);
        }

        var allNodes = graph.Nodes;

        foreach (Node n in allNodes)
        {
            Gizmos.color = n.IsOccupied ? Color.red : Color.green;
            Gizmos.DrawSphere(n.WorldPosition, 0.1f);
        }
    }
}
