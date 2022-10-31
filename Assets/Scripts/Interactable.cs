using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool playerInRange;
    protected PlayerAnimation player;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        player = other.GetComponent<PlayerAnimation>();

        if (player != null)
        {
            playerInRange = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        player = other.GetComponent<PlayerAnimation>();

        if (player != null)
        {
            playerInRange = false;
        }
    }
}
