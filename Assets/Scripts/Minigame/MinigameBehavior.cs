using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class MinigameBehavior : MonoBehaviour
{
    [Header("Bed Minigame Components")]
    [SerializeField] Animator bedGameAnimator;
    [SerializeField] GameObject bedGame;

    [Header("Bed Minigame Variables")]
    public bool bedGameStart = false;
    float flashlightTimer = 5f;

    [Header("Window Minigame Components")]
    [SerializeField] Animator windowGameAnimator;
    [SerializeField] GameObject windowGame;

    [Header("Window Minigame Variables")]
    public bool windowGameStart = false;

    [Header("Homework Minigame Components")]
    [SerializeField] Animator homeworkGameAnimator;
    [SerializeField] GameObject homeworkGame;
    public bool homeworkGameStart = false;

    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        bedGame.SetActive(false);
        windowGame.SetActive(false);
        homeworkGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateBedGameState(bool newState)
    {
        bedGameStart = newState;
        bedGame.SetActive(newState);
        bedGameAnimator.SetBool("StartPopup", bedGameStart);
        if ( newState == false )
        {
            player.ReactivateMovement();
        }
    }

    public float GetFlashlightTimer()
    {
        return flashlightTimer;
    }

    public void UpdateWindowGameState(bool newState)
    {
        windowGameStart = newState;
        windowGame.SetActive(newState);
        windowGameAnimator.SetBool("StartPopup", windowGameStart);
        if ( newState == false)
        {
            player.ReactivateMovement();
        }
    }

    public void UpdateHomeworkGameState(bool newState)
    {
        homeworkGameStart = newState;
        homeworkGame.SetActive(newState);
        homeworkGameAnimator.SetBool("StartPopup", homeworkGameStart);
    }
}
public enum minigameType
{
    None,
    Bed,
    Window,
    Homework
}