using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : Interactable
{
    [SerializeField] private Item hoeItem;

    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Inventory.Instance.AddItem(hoeItem);
            Destroy(this.gameObject);
        }
    }
}
