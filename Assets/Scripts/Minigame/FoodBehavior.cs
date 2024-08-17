using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FoodBehavior : MonoBehaviour
{
    [SerializeField] Canvas parentCanvas;
    MinigameBehavior minigameBehavior;

    [SerializeField] Vector2 mousePos;
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
        if (minigameBehavior.windowGameStart)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, Input.mousePosition, parentCanvas.worldCamera, out mousePos);
            
        }
    }
}
