using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject rectanglePrefab;

    [SerializeField]
    private List<Node> nodes;

    [SerializeField]
    private int[][] matrixAdj;


    // Start is called before the first frame update
    void Start()
    {
        nodes ??= new List<Node>();

        int numNodes = nodes.Count;

        matrixAdj = new int[numNodes][];

        for (int i = 0; i < numNodes; i++)
        {
            matrixAdj[i] = new int[numNodes];
            nodes[i].setId(i);

            for (int j = 0; j < numNodes; j++)
            {
                matrixAdj[i][j] = 0;
            }
        }

        SetAdj();
    }

    public void SetAdj()
    {
        foreach (Node node in nodes)
        {
            int currentNodeId = node.getId();

            foreach (Node adjNode in node.getNodesAdj())
            {
                int adjNodeId = adjNode.getId();

                matrixAdj[currentNodeId][adjNodeId] = 1;

                if (!adjNode.isAdjacente(node))
                {
                    adjNode.setNodeAdj(node);
                }

                if (matrixAdj[adjNodeId][currentNodeId] != 1)
                {
                    // Calcule a posição média entre os dois nodes adjacentes.
                    Vector3 position = (node.transform.position + adjNode.transform.position) / 2f;

                    // Calcule o tamanho do retângulo com base na distância entre os nodes adjacentes.
                    float width = Vector3.Distance(node.transform.position, adjNode.transform.position);
                    float height = 0.06f; // Defina a espessura do retângulo.

                    // Crie o retângulo usando o prefab.
                    GameObject rectangle = Instantiate(rectanglePrefab, position, Quaternion.identity);

                    // Configure o tamanho do retângulo.
                    rectangle.transform.localScale = new Vector3(width, height, 1f);

                    // Certifique-se de que o retângulo está alinhado com a linha entre os nodes.
                    Vector3 direction = (adjNode.transform.position - node.transform.position).normalized;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    rectangle.transform.rotation = Quaternion.Euler(0f, 0f, angle);

                    rectangle.transform.position = new Vector3(rectangle.transform.position.x,
                        rectangle.transform.position.y,
                        rectangle.transform.position.z + 1);
                }
            }
        }
    }
}
