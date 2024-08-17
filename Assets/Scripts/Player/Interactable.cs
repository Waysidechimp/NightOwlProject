using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] minigameType minigameType;

    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region player interaction
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player is in range");
            player = collision.gameObject.GetComponent<PlayerMovement>();
            player.GetMinigameType(minigameType);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(player != null && player.isInteracting)
        {
            Debug.Log("PLayer is interacting");
        }
        player.isInteracting = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player is out of range");
            player.GetMinigameType(minigameType.None);
            player = null;
        }
    }
    #endregion
}
