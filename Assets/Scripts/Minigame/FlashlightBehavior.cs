using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightBehavior : MonoBehaviour
{
    [SerializeField] MonsterManager monsterManager;
    [SerializeField] Canvas parentCanvas;
    MinigameBehavior minigameBehavior;

    Vector2 pos;
    float maxTimer = 5f;
    [SerializeField]
    float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        minigameBehavior = FindObjectOfType<MinigameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        TrackMouse();
    }

    void TrackMouse()
    {
        if (minigameBehavior.minigameStart)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, Input.mousePosition, parentCanvas.worldCamera, out pos);
            transform.position = parentCanvas.transform.TransformPoint(pos);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "BedMonster")
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = maxTimer;
                Debug.Log("Monster Slain");
                monsterManager.BanishMonster();
                minigameBehavior.UpdateMinigameState(false);
                minigameBehavior.gameObject.GetComponent<PlayerMovement>().ReactivateMovement();
            }
        }
    }
}
