using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightBehavior : MonoBehaviour
{
    [SerializeField] MonsterManager monsterManager;
    [SerializeField] Canvas parentCanvas;
    MinigameBehavior minigameBehavior;

    Vector2 mousePos;
    float maxTimer = 5f;
    float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        minigameBehavior = FindObjectOfType<MinigameBehavior>();
        maxTimer = minigameBehavior.GetFlashlightTimer();
    }

    // Update is called once per frame
    void Update()
    {
        TrackMouse();
    }

    void TrackMouse()
    {
        if (minigameBehavior.bedGameStart)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, Input.mousePosition, parentCanvas.worldCamera, out mousePos);
            transform.position = parentCanvas.transform.TransformPoint(mousePos);
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
                monsterManager.BanishMonster();
                gameObject.transform.position = new Vector2(-578, 301);
                minigameBehavior.UpdateBedGameState(false);
            }
        }
    }
}
