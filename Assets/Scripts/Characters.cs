using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Characters : MonoBehaviour
{
    public Sprite imageChar;
    public Game game;
    public Manager manager;

    public void StartChar(List<Node> nodes, Manager _manager)
    {
        manager = _manager;
        StartCoroutine(Movendo(nodes));
    }

    IEnumerator Movendo(List<Node> nodes)
    {
        foreach (Node node in nodes)
        {
            gameObject.LeanMoveLocal(node.transform.localPosition, 2f/manager.speed).setEaseInOutQuad();
            yield return new WaitForSeconds(2f/manager.speed);
        }

        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    public void SelectedChar()
    {
        game.SelectionCharacter(this);
    }
}
