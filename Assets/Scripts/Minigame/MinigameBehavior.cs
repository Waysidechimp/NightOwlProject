using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MinigameBehavior : MonoBehaviour
{
    [SerializeField] Animator minigameAnimator;

    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isInteracting == true)
        {
            minigameAnimator.SetBool("StartPopup", true);
        }
        else
        {
            minigameAnimator.SetBool("StartPopup", false);
        }
    }
}
