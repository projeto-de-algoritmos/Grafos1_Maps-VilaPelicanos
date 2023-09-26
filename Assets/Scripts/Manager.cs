using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public AlgorithmBFS algorithBFS;
    public Game game;

    public List<Node> graph;
    public Node startCharacter01;
    public Node endCharacter01;
    public Node startCharacter02;
    public Node endCharacter02;
    public int friendship;
    public Slider slider;
    public TextMeshProUGUI valueFriendship;

    [SerializeField]
    private int[][] matrixAdj;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(UpdateSliderValue);

        graph ??= new List<Node>();

        int numNodes = graph.Count;

        matrixAdj = new int[numNodes][];

        for (int i = 0; i < numNodes; i++)
        {
            matrixAdj[i] = new int[numNodes];
            graph[i].setId(i);

            for (int j = 0; j < numNodes; j++)
            {
                matrixAdj[i][j] = 0;
            }
        }

        SetAdj();
    }

    public void StartGame()
    {
        List<Node> nodes = algorithBFS.BFS(graph, startCharacter01, endCharacter01);

        if (nodes.Count != 0)
            game.CreateCharacter(nodes[0], nodes);
    }

    // Fun��o chamada quando o valor do slider � alterado.
    void UpdateSliderValue(float newValue)
    {
        friendship = ((int)newValue);
        valueFriendship.text = friendship.ToString();
    }

    public void SetAdj()
    {
        foreach (Node node in graph)
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
                    // Calcule a posi��o m�dia entre os dois n�s adjacentes.
                    Vector3 position = (node.transform.localPosition + adjNode.transform.localPosition) / 2f;

                    // Calcule a dist�ncia entre os n�s adjacentes.
                    float distance = Vector3.Distance(node.transform.localPosition, adjNode.transform.localPosition);

                    // Crie a imagem retangular usando o prefab.
                    Image edgeImage = Instantiate(edgePrefab, position, Quaternion.identity);

                    // Defina o tamanho da imagem retangular com base na dist�ncia entre os n�s adjacentes.
                    edgeImage.rectTransform.sizeDelta = new Vector2(distance, 4f); // 4f � a espessura da linha.

                    edgeImage.transform.SetParent(parentEdge);
                    edgeImage.transform.localPosition = position;

                    // Certifique-se de que a imagem retangular est� alinhada com a linha entre os n�s.
                    Vector3 direction = (adjNode.transform.localPosition - node.transform.localPosition).normalized;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    edgeImage.rectTransform.rotation = Quaternion.Euler(0f, 0f, angle);
                }
            }
        }
    }
}
