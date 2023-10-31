using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    public List<Node> Nodes;
    public List<Edge> Edges;

    public Graph()
    {
        Nodes = new List<Node>();
        Edges = new List<Edge>();
    }

    public void AddNode(Vector3 worldPosition)
    {

    }

    public void AddEdge(Node from, Node to)
    {

    }

    public bool Adjacent(Node from, Node to)
    {
        foreach (Edge e in Edges)
        {
            if (e.From == from && e.To == to)
                return true;
        }

        return false;
    }

    public List<Node> Neighbours(Node of)
    {
        List<Node> result = new List<Node>();
        foreach (Edge e in Edges)
        {
            if (e.From == of)
                result.Add(e.To);
        }

        return result;
    }

    public float Distance(Node from, Node to)
    {
        foreach(Edge e in Edges)
        {
            if (e.From == from && e.To == to)
                return e.GetWeight();
        }

        return Mathf.Infinity;
    }
}

public class Node
{
    public int Index;
    public Vector2 WorldPosition;

    private bool occupied;
    public bool IsOccupied => occupied;

    public Node(int index, Vector2 worldPosition)
    {
        this.Index = index;
        this.WorldPosition = worldPosition;
        this.occupied = false;
    }

    public void SetOccupied(bool occupied)
    {
        this.occupied = occupied;
    }
}

public class Edge
{
    public Node From;
    public Node To;

    private float weight;

    public Edge(Node from, Node to, float weight)
    {
        this.From = from;
        this.To = to;
        this.weight = weight;
    }

    public float GetWeight()
    {
        if (To.IsOccupied)
        {
            return Mathf.Infinity;
        }
        return weight;
    }
}