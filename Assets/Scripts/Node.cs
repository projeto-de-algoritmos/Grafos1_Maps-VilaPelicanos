using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    [SerializeField]
    private int id;

    [SerializeField]
    private List<Node> nodesAdj = new();

    public Game game;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(ClickNode);
    }

    public int getId()
    {
        return id;
    }

    public void setId(int _id)
    {
        id = _id;
    }

    public List<Node> getNodesAdj()
    {
        return nodesAdj;
    }

    public void setNodeAdj(Node node)
    {
        nodesAdj.Add(node);
    }

    public bool isAdjacente(Node node)
    {
        return nodesAdj.Contains(node) && node != this;
    }

    public void setNodesAdj(List<Node> nodes)
    {
        nodesAdj = nodes;
    }

    public void ClickNode()
    {
        game.SelectionNode(this);
    }
}
