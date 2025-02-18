using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehavior : MonoBehaviour
{
    [SerializeField] Canvas parentCanvas;
    MinigameBehavior minigameBehavior;
    [SerializeField] 
    MonsterManager monsterManager;

    BoxCollider2D thisCollider;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        thisCollider = GetComponent<BoxCollider2D>();
        minigameBehavior = FindObjectOfType<MinigameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        TrackMouse();
        
        if (Input.GetMouseButton(0) && thisCollider.OverlapPoint(Input.mousePosition))
        {
            transform.position = parentCanvas.transform.TransformPoint(mousePos);
        }
        else
        {
            gameObject.transform.position = transform.parent.position;
        }
    }
    void TrackMouse()
    {
        if (minigameBehavior.windowGameStart)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, Input.mousePosition, parentCanvas.worldCamera, out mousePos);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "WindowMonsterHand")
        {
            Debug.Log("Monster Fed");
            monsterManager.windowBanishMonster();
            gameObject.transform.position = transform.parent.position;
            minigameBehavior.UpdateWindowGameState(false);
        }
    }
}
