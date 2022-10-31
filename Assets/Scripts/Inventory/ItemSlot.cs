using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public event Action OnChange;

    public Item Item;
    public int StackCount;

    public bool HasStackSpaceAvailable => StackCount < Item.MaxStackSize;

    public bool IsEmpty => Item == null;

    public void SetItem(Item item, int stackCount = 1)
    {
        Item = item;
        StackCount = stackCount;
        OnChange?.Invoke();
    }

    public void RemoveItem()
    {
        SetItem(null);
    }

    public void ModifyStack(int amount)
    {
        StackCount += amount;
        if(StackCount <= 0)
        {
            SetItem(null);
        }
        else
        {
            OnChange?.Invoke();
        }
    }
}
