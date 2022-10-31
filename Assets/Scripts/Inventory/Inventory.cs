using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int INVENTORY_SIZE = 9;

    public ItemSlot[] InventorySlots = new ItemSlot[INVENTORY_SIZE];
    
    private int numberSlotSelected;

    public static Inventory Instance { get; private set; }
    public ItemSlot focusedSlot { get; private set; }

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < INVENTORY_SIZE; i++)
        {
            InventorySlots[i] = new ItemSlot();
        }
    }

    void Start()
    {
        numberSlotSelected = 0;
        focusedSlot = InventorySlots[numberSlotSelected];
    }

    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(numberSlotSelected < INVENTORY_SIZE-1)
            {
                numberSlotSelected++;
            }
            else
            {
                numberSlotSelected = 0;
            }

            focusedSlot = InventorySlots[numberSlotSelected];
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(numberSlotSelected <= 0)
            {
                numberSlotSelected = INVENTORY_SIZE-1;
            }
            else
            {
                numberSlotSelected--;
            }

            focusedSlot = InventorySlots[numberSlotSelected];
        }
    }

    public void AddItem(Item item)
    {
        if (AddItemToSlot(item, InventorySlots))
            return;
    }

    private bool AddItemToSlot(Item item, ItemSlot[] inventorySlots)
    {
        var stackableSlot = inventorySlots.FirstOrDefault(t => t.Item == item && t.HasStackSpaceAvailable);
        if(stackableSlot != null)
        {
            stackableSlot.ModifyStack(1);
            return true;
        }

        var slot = inventorySlots.FirstOrDefault(t => t.IsEmpty);
        if(slot != null)
        {
            slot.SetItem(item);
            return true;
        }

        return false;
    }
}
