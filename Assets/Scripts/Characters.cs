using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public Sprite imageChar;
    public Game game;

    public void MoveChar(Node target)
    {
        gameObject.LeanMoveLocal(target.transform.localPosition, 2f).setEaseInOutQuad();
    }

    public void SelectedChar()
    {
        game.SelectionCharacter(this);
    }
}
