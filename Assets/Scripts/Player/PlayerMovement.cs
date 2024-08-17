using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.ScrollRect;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] public bool isInteracting;

    MinigameBehavior minigameBehavior;
    PlayerInput input;
    Rigidbody2D rb2d;
    Vector2 movementVector;
    private void Awake()
    {
        minigameBehavior = GetComponent<MinigameBehavior>();
        rb2d = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
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

    void OnInteract(InputValue value)
    {
        minigameBehavior.UpdateMinigameState(true);
        isInteracting = true;
        input.currentActionMap.Disable();
    }

    public void ReactivateMovement()
    {
        input.currentActionMap.Enable();
    }
}
