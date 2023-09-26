using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Characters : MonoBehaviour
{
    public Sprite imageChar;
    public Game game;

    public void StartChar(List<Node> nodes)
    {
        StartCoroutine(Movendo(nodes));
    }

    IEnumerator Movendo(List<Node> nodes)
    {
        foreach (Node node in nodes)
        {
            gameObject.LeanMoveLocal(node.transform.localPosition, 2f).setEaseInOutQuad();
            yield return new WaitForSeconds(2f);
        }

        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    public void SelectedChar()
    {
        game.SelectionCharacter(this);
    }
}
