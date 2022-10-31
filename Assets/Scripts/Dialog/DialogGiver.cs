using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogGiver : Interactable
{
    [SerializeField] private Dialog firstDialog;
    [SerializeField] private Dialog stillActiveQuestDialog;
    [SerializeField] private Dialog completedQuestDialog;

    [SerializeField] private Quest quest;

    private void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            BeginDialog();
        }
    }

    public void BeginDialog()
    {
        if (quest.IsCompleted())
        {
            DialogManager.Instance.StartDialog(completedQuestDialog);
            quest.IsDone = true;
            return;
        }

        if (!quest.IsActive)
        {
            DialogManager.Instance.StartDialog(firstDialog);
            quest.IsActive = true;
            return;
        }


        if(quest.IsActive && !quest.IsCompleted() && !quest.IsDone)
        {
            DialogManager.Instance.StartDialog(stillActiveQuestDialog);
            return;
        }

    }
}
