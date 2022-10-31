using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bed : Interactable
{
    public static event Action OnTimeChange;

    [SerializeField] private Animator dayTransitioAnimator;
    [SerializeField] private CanvasGroup dayTransitionCanvasGroup;

    void Start()
    {
        DisableCanvas();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            playerInRange = false;
            StartCoroutine(FadeAndChangeDay());
            
        }
    }

    private IEnumerator FadeAndChangeDay()
    {
        EnableCanvas();

        dayTransitioAnimator.SetTrigger("Begin");

        yield return new WaitForSeconds(2f);

        OnTimeChange?.Invoke();

        yield return new WaitForSeconds(.5f);

        dayTransitioAnimator.SetTrigger("End");

        yield return new WaitForSeconds(2f);

        DisableCanvas();
    }

    private void EnableCanvas()
    {
        dayTransitionCanvasGroup.alpha = 1;
        dayTransitionCanvasGroup.blocksRaycasts = true;
        dayTransitionCanvasGroup.interactable = true;
    }

    private void DisableCanvas()
    {
        dayTransitionCanvasGroup.alpha = 0;
        dayTransitionCanvasGroup.blocksRaycasts = false;
        dayTransitionCanvasGroup.interactable = false;
    }
}
