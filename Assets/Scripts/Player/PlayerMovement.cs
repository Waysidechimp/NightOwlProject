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
    [SerializeField]
    Animator animator;

    minigameType currentMinigameInRange = minigameType.None;
    private void Awake()
    {
        minigameBehavior = GameObject.Find("MinigameManager").GetComponent<MinigameBehavior>();
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
        animator.SetFloat("y-axisVelocity", movementVector.y);
        animator.SetFloat("x-axisVelocity", movementVector.x);
    }

    void OnInteract(InputValue value)
    {
        switch (currentMinigameInRange)
        {
            case minigameType.Bed:
                minigameBehavior.UpdateBedGameState(true);
                input.currentActionMap.Disable();
                break;
            case minigameType.Window:
                minigameBehavior.UpdateWindowGameState(true);
                input.currentActionMap.Disable();
                break;
            case minigameType.Homework:
                minigameBehavior.UpdateHomeworkGameState(true);
                input.currentActionMap.Disable();
                break;
            default:
                break;
        }
        isInteracting = true;
    }

    public void ReactivateMovement()
    {
        input.currentActionMap.Enable();
    }

    public void GetMinigameType(minigameType minigameType)
    {
        currentMinigameInRange = minigameType;
    }
}
