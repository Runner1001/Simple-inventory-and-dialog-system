using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Quest
{
    public int amountRequired;
    public ObjectType objectTypeRequired;
    public int GoldReward;
    public bool IsActive;
    public bool IsDone;

    public bool IsCompleted()
    {
        var slot = Inventory.Instance.InventorySlots.Where(t=> t.Item !=null).FirstOrDefault(t => t.Item.ObjectType == objectTypeRequired && t.StackCount >= amountRequired);
        
        if(slot != null)
        {
            slot.ModifyStack(-amountRequired);
            MoneyManager.ModifyMoney(GoldReward);
            return true;
        }
        else
        {
            return false;
        }
    }
}
