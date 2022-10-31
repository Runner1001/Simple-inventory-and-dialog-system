using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelSlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private Outline outline;
    [SerializeField] private TMP_Text stackCountText;

    private ItemSlot itemSlot;

    private void Update()
    {
        if(Inventory.Instance.focusedSlot == itemSlot)
        {
            outline.enabled = true;
        }
        else
        {
            outline.enabled = false;
        }
    }

    public void Bind(ItemSlot itemSlot)
    {
        this.itemSlot = itemSlot;
        itemSlot.OnChange += UpdateIconAndStackSize;
        UpdateIconAndStackSize();
    }

    private void UpdateIconAndStackSize()
    {
        if(itemSlot.Item != null)
        {
            itemIcon.sprite = itemSlot.Item.Icon;
            itemIcon.enabled = true;
            stackCountText.SetText(itemSlot.StackCount.ToString());
            stackCountText.enabled = itemSlot.Item.MaxStackSize > 1;
        }
        else
        {
            itemIcon.sprite = null;
            itemIcon.enabled = false;
            stackCountText.enabled = false;
        }
    }
}
