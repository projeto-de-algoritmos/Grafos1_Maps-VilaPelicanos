using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AlgorithmBFS : MonoBehaviour
{
    [SerializeField]
    private Manager manager;
    private List<Node> newGraph = new();

    public void Add_Node(Node node)
    {
        Node newNode = new();
        newNode.setId(node.getId());
        newNode.setNodesAdj(new List<Node>());

        newGraph.Add(newNode); // O(1)
    }// Complexidade operação O(1)
    public void Add_Edge(Node node, Node nodeAdj)
    {
        newGraph[newGraph.IndexOf(node)].setNodeAdj(nodeAdj); // O(n)
        newGraph[newGraph.IndexOf(nodeAdj)].setNodeAdj(node); // O(n)
    }// Complexidade operação O(n)

    public List<Node> BFS(List<Node> nodes, Node s, Node t)
    {
        int[] visited = new int[manager.graph.Count];
        Array.Fill(visited, -1);

        Queue<Node> queue = new();
        List<Node> path = new();

        visited[s.getId()] = s.getId();

        queue.Enqueue(s);

        while (queue.Any())
        {   // O(n)

            Node node = queue.Dequeue();

            foreach (Node nodeAdj in node.getNodesAdj())
            {   // O(m)

                int id = nodeAdj.getId();

                if (visited[id] == -1)
                {
                    visited[id] = node.getId();
                    queue.Enqueue(nodeAdj);

                    if (nodeAdj == t)
                    {
                        Node temp = t;
                        while (temp != s)
                        {   // O(n)

                            path.Add(temp);
                            temp = nodes[visited[temp.getId()]];
                        }
                        path.Add(s);
                        path.Reverse();
                        return path;
                    }
                }
            }
        }

        return new List<Node>(); // Retorna uma lista vazia quando não há caminho entre s e t
    }

    public void Start()
    {
        StartCoroutine(startAlgorithm());
    }

    IEnumerator startAlgorithm()
    {
        yield return new WaitForSeconds(5);

        AlgorithmBFS algorithmBFS = new();

        List<Node> caminho = BFS(manager.graph, manager.graph[47], manager.graph[4]);

        foreach (Node node in caminho)
        {
            Debug.Log(node.getId() + "->");
        }
    }
}
