using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private CanvasGroup dialogCanvas;

    private Queue<string> sentences;

    public static DialogManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        sentences = new Queue<string>();
        DisableDialogCanvas();
    }

    public void StartDialog(Dialog dialog)
    {
        sentences.Clear();

        EnableDialogCanvas();

        foreach (var sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count == 0)
        {
            CloseDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    private void CloseDialog()
    {
        DisableDialogCanvas();
    }

    private void EnableDialogCanvas()
    {
        dialogCanvas.alpha = 1;
        dialogCanvas.blocksRaycasts = true;
        dialogCanvas.interactable = true;
    }

    private void DisableDialogCanvas()
    {
        dialogCanvas.alpha = 0;
        dialogCanvas.blocksRaycasts = false;
        dialogCanvas.interactable = false;
    }
}
