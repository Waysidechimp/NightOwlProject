using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.ScrollRect;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    Rigidbody2D rb2d;

    Vector2 movementVector;
    Vector2 sideMoveVector;
    Vector2 vertMoveVector;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement(walkSpeed);
    }

    void Movement(float moveSpeed)
    {
        rb2d.velocity = movementVector;
    }

    void OnWalking(InputValue value)
    {
        movementVector = value.Get<Vector2>();
        movementVector *= walkSpeed;
    }
}
