using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIExit : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        DisableCanvas();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EnableCanvas();
        }
    }

    private void EnableCanvas()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public void DisableCanvas()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
