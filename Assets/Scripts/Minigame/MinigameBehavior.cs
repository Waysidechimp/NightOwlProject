using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MinigameBehavior : MonoBehaviour
{
    [SerializeField] Animator minigameAnimator;

    PlayerMovement player;
    public bool minigameStart = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        minigameAnimator.SetBool("StartPopup", minigameStart);
    }

    public void UpdateMinigameState(bool newState)
    {
        minigameStart = newState;
    }
}
