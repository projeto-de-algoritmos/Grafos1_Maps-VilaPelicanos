using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    private bool isOpen = false;
    private bool isAnimating = false;

    public GameObject config;


    public void ClickMenu()
    {
        if (isAnimating)
            return;

        isAnimating = true;

        if (isOpen)
            StartCoroutine(CloseConfig());
        else
            StartCoroutine(OpenConfig());
    }

    IEnumerator OpenConfig() 
    {
        isOpen = true;
        config.LeanMoveLocal(new Vector3(0, 550f, 0), 1f).setEaseInOutQuad();
        yield return new WaitForSeconds(1f);
        isAnimating = false;
    }

    IEnumerator CloseConfig()
    {
        isOpen = false;
        config.LeanMoveLocal(new Vector3(0, 720f, 0), 1f).setEaseInOutQuad();
        yield return new WaitForSeconds(1f);
        isAnimating = false;
    }
}
