using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Interactable
{
    [SerializeField] private Item mushroomItem;

    void Update()
    {
        if(playerInRange && Input.GetMouseButtonDown(0))
        {
            if(Inventory.Instance.focusedSlot.Item != null && Inventory.Instance.focusedSlot.Item.ObjectType == ObjectType.Hoe)
            {
                player.IsHarvesting = true;
                Inventory.Instance.AddItem(mushroomItem);
                Destroy(gameObject);
            }
        }
    }
}
