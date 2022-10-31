using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerInput playerInput;

    public bool IsHarvesting { get; set; }

    void Start()
    {
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();

        anim.SetFloat("MoveX", 0);
        anim.SetFloat("MoveY", -1);
    }

    void Update()
    {
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        if(playerInput.Move != Vector3.zero)
        {
            anim.SetFloat("MoveX", playerInput.Move.x);
            anim.SetFloat("MoveY", playerInput.Move.y);
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }

        if (IsHarvesting)
        {
            anim.SetTrigger("Harvest");
            IsHarvesting = false;
        }
    }
}
