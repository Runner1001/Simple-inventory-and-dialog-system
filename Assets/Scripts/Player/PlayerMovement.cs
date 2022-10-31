using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private PlayerInput playerInput;
    private Rigidbody2D rb;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (playerInput.Move != Vector3.zero)
        {
            playerInput.Move.Normalize();

            rb.MovePosition(transform.position + playerInput.Move * speed * Time.deltaTime);
        }
    }
}
