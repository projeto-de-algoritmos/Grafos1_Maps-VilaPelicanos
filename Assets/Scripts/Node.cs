using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    private int id;

    [SerializeField]
    private List<Node> nodesAdj = new();

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
}
