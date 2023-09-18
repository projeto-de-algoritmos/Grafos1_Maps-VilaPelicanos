using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField]
    private CanvasGroup banner;

    [SerializeField]
    private CanvasGroup playButton;

    [SerializeField]
    private CanvasGroup clouds;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(1);

        banner.LeanAlpha(1, 2f).setEaseInQuad();

        yield return new WaitForSeconds(.5f);

        playButton.LeanAlpha(1, 2).setEaseInQuad();

        yield return new WaitForSeconds(.5f);

        clouds.LeanAlpha(1, 2).setEaseInQuad();
    }
}
