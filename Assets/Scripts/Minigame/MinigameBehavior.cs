using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class MinigameBehavior : MonoBehaviour
{
    [Header("OverallGameVariables")]
    [SerializeField] float maxGameTimer;
    [SerializeField] float gameTimer;
    [SerializeField] AudioClip endGameSound;
    [SerializeField] AudioClip gameMusic;
    AudioSource gameSource;

    [Header("Bed Minigame Components")]
    [SerializeField] Animator bedGameAnimator;
    [SerializeField] GameObject bedGame;

    [Header("Bed Minigame Variables")]
    public bool bedGameStart = false;
    [SerializeField] float flashlightTimer = 5f;

    [Header("Window Minigame Components")]
    [SerializeField] Animator windowGameAnimator;
    [SerializeField] GameObject windowGame;

    [Header("Window Minigame Variables")]
    public bool windowGameStart = false;

    [Header("Homework Minigame Components")]
    [SerializeField] Animator homeworkGameAnimator;
    [SerializeField] GameObject homeworkGame;

    [Header("Homeowork Minigame Variables")]
    public bool homeworkGameStart = false;

    [Header("Grade Components")]
    [SerializeField] Animator gradeAnimator;
    [SerializeField] GameObject gradeObject;

    [Header("Homeowork Minigame Variables")]
    public bool gradeStart = false;
    int grade;

    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        gameSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        bedGame.SetActive(false);
        windowGame.SetActive(false);
        homeworkGame.SetActive(false);
        gradeObject.SetActive(false);
        gameTimer = maxGameTimer;
    }

    // Update is called once per frame
    void Update()
    {
        RunTimer();
    }

    #region Minigame Methods

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
        if (newState == false)
        {
            player.ReactivateMovement();
        }
    }

    public void UpdateGrade(int playerGrade)
    {
        grade = playerGrade;
    }

    public void UpdateGradeState(bool newState)
    {
        gradeStart = newState;
        gradeObject.SetActive(newState);
        gradeAnimator.SetBool("StartPopup", gradeStart);
    }

    public int GetGrade()
    {
        return grade;
    }

    #endregion

    void RunTimer()
    {
        if (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime;
        }
        else
        {
            gameTimer = maxGameTimer;
            UpdateBedGameState(false);
            UpdateWindowGameState(false);
            UpdateHomeworkGameState(false);
            UpdateGrade(0);
            UpdateGradeState(true);
        }
    }

    public void EndGame()
    {
        UpdateBedGameState(false);
        UpdateWindowGameState(false);
        UpdateHomeworkGameState(false);
        UpdateGrade(0);
        UpdateGradeState(true);
        gameSource.clip = endGameSound;
        gameSource.Play();
        /*gameSource.clip = gameMusic;
        gameSource.Play();*/
    }
}
public enum minigameType
{
    None,
    Bed,
    Window,
    Homework
}