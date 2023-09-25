using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField]
    private Image edgePrefab;

    [SerializeField]
    private Transform parentEdge;

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
                    // Calcule a posição média entre os dois nós adjacentes.
                    Vector3 position = (node.transform.localPosition + adjNode.transform.localPosition) / 2f;

                    // Calcule a distância entre os nós adjacentes.
                    float distance = Vector3.Distance(node.transform.localPosition, adjNode.transform.localPosition);

                    // Crie a imagem retangular usando o prefab.
                    Image edgeImage = Instantiate(edgePrefab, position, Quaternion.identity);

                    // Defina o tamanho da imagem retangular com base na distância entre os nós adjacentes.
                    edgeImage.rectTransform.sizeDelta = new Vector2(distance, 4f); // 6f é a espessura da linha.

                    edgeImage.transform.SetParent(parentEdge);
                    edgeImage.transform.localPosition = position;

                    // Certifique-se de que a imagem retangular está alinhada com a linha entre os nós.
                    Vector3 direction = (adjNode.transform.localPosition - node.transform.localPosition).normalized;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    edgeImage.rectTransform.rotation = Quaternion.Euler(0f, 0f, angle);

                    // Defina a cor da imagem retangular, se necessário.
                    // edgeImage.color = Color.red;
                }
            }
        }
    }
}
