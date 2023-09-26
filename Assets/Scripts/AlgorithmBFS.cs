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

    struct NewNode
    {
        public Dictionary<int, int> ids;

        public List<NewNode> newNodes;
    }

    public List<Node> BFS(List<Node> nodes, Node s, Node t)
    {   // Complexidade operacao O(n+m)

        int[] visited = new int[nodes.Count];
        Array.Fill(visited, -1);

        Queue<Node> queue = new();
        List<Node> path = new();

        visited[s.getId()] = s.getId();

        queue.Enqueue(s);

        while (queue.Any())
        {   // Complexidade operacao O(n), considerando que todos os nos serao emfileirados uma unica vez

            Node node = queue.Dequeue();

            foreach (Node nodeAdj in node.getNodesAdj())
            {   // Complexidade operacao O(m), O(deg(nodeAdj)) para cada vertice, no pior caso percorre todos os nos, sendo um somatorio dos graus de cada no igual a 2m

                int id = nodeAdj.getId();

                if (visited[id] == -1)
                {
                    visited[id] = node.getId();
                    queue.Enqueue(nodeAdj);

                    if (nodeAdj.Equals(t))
                    {
                        Node temp = t;

                        while (!temp.Equals(s))
                        {   // O(n), pois pode no maximo passar por todos os nos para chegar ao destino

                            path.Insert(0, temp);
                            temp = nodes[visited[temp.getId()]];

                        }
                        path.Insert(0, s);
                        return path;
                    }
                }
            }
        }

        return new List<Node>(); // Retorna uma lista vazia quando nao ha caminho entre s e t
    }

    public void Start()
    {
        StartCoroutine(startAlgorithm());
    }

    IEnumerator startAlgorithm()
    {
        yield return new WaitForSeconds(5);

        List<Node> caminho = BFS(manager.graph, manager.graph[47], manager.graph[4]);

        foreach (Node node in caminho)
        {
            Debug.Log(node.getId() + "->");
        }
    }
}
