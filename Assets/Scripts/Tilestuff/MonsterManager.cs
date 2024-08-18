using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class MonsterManager : MonoBehaviour
{
    [Header("Audio Assets")]
    [SerializeField] AudioClip bedSound;
    [SerializeField] AudioClip windowSound;
    AudioSource soundSource;

    [Header("Minigame Assets")]
    [SerializeField] GameObject bedCollision;
    [SerializeField] GameObject windowCollision;
    [SerializeField] MinigameBehavior minigameBehavior;

    [Header("Monster Manager Assets")]
    [FormerlySerializedAs("Solidmap")] [FormerlySerializedAs("map")] [SerializeField]
    private Tilemap solidmap;
    [SerializeField]
    private Tilemap softmap;
    [SerializeField]
    private Tilemap wallmap;
    
    // Bed Monster stages
    [FormerlySerializedAs("firstStage")] [SerializeField]
    private TileBase firstStage1;
    [SerializeField]
    private TileBase firstStage2;
    [FormerlySerializedAs("secondStage")] [SerializeField]
    private TileBase secondStage1;
    [SerializeField]
    private TileBase secondStage2;
    [FormerlySerializedAs("finalStage")] [SerializeField]
    private TileBase finalStage1;
    [SerializeField]
    private TileBase finalStage2;
    
    [FormerlySerializedAs("bedmonsterPosition")] [SerializeField]
    private Vector3Int bedmonsterPosition1 = new Vector3Int(0, 2, 0);
    [SerializeField]
    private Vector3Int bedmonsterPosition2 = new Vector3Int(0, 0, 0);

    [SerializeField] private float angerInterval = 20;
    
    [FormerlySerializedAs("angerTimer")] [SerializeField]
    private float bedMonsterAngerTimer = 20;
    
    [SerializeField]
    private byte bedMonsterAnger = 1;
    
    //Window monster stuff
    [SerializeField]
    private TileBase windowFirstStage1;
    [SerializeField]
    private TileBase windowFirstStage2;
    [SerializeField]
    private TileBase windowSecondStage1;
    [SerializeField]
    private TileBase windowSecondStage2;
    [SerializeField]
    private TileBase windowFinalStage1;
    [SerializeField]
    private TileBase windowFinalStage2;
    
    [SerializeField]
    private Vector3Int windowMonsterPosition1 = new Vector3Int(0, 2, 0);
    [SerializeField]
    private Vector3Int windowMonsterPosition2 = new Vector3Int(0, 0, 0);

    [SerializeField]
    private float windowMonsterAngerTimer = 20;
    [SerializeField]
    private float windowAngerInterval = 20;

    [SerializeField]
    private byte windowMonsterAnger = 1;

    //update tiles
    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        bedCollision.SetActive(false);
        windowCollision.SetActive(false);
    }

    internal void Update()
    {
        bedMonsterAngerTimer -= Time.deltaTime;
        windowMonsterAngerTimer -= Time.deltaTime;

        if (bedMonsterAngerTimer <= 0)
        {
            BedIncreaseAngerStage();
            bedMonsterAngerTimer = angerInterval;
        }

        if (windowMonsterAngerTimer <= 0)
        {
        WindowIncreaseAngerStage();
        windowMonsterAngerTimer = windowAngerInterval;
        }
}

    private void BedIncreaseAngerStage()
    {
        soundSource.clip = bedSound;
        switch (bedMonsterAnger)
        {
            case 0 : solidmap.SetTile(bedmonsterPosition1, firstStage1);
                solidmap.SetTile(bedmonsterPosition2, firstStage2);
                bedMonsterAnger++;
                break;
            case 1 : solidmap.SetTile(bedmonsterPosition1, firstStage1); 
                solidmap.SetTile(bedmonsterPosition2, firstStage2);
                bedMonsterAnger++;
                break;
            case 2 : solidmap.SetTile(bedmonsterPosition1, secondStage1);
                solidmap.SetTile(bedmonsterPosition2, secondStage2);
                bedMonsterAnger++;
                bedCollision.SetActive(true);
                soundSource.Play();
                break;
            case 3 : solidmap.SetTile(bedmonsterPosition1, finalStage1);
                solidmap.SetTile(bedmonsterPosition2, finalStage2);
                bedMonsterAnger++;
                bedCollision.SetActive(true);
                soundSource.Play();
                break;
            case 4 : 
                minigameBehavior.EndGame();
                break;
            default:
                Debug.Log("Error");
                bedMonsterAnger = 0;
                throw new ArgumentException("Invalid anger stage");
            
        }
        if(bedMonsterAnger >= 2)
        {

        }
        
    }
    private void WindowIncreaseAngerStage()
    {
        soundSource.clip = windowSound;
        switch (windowMonsterAnger)
        {
            case 0 : wallmap.SetTile(windowMonsterPosition1, windowFirstStage1);
                softmap.SetTile(windowMonsterPosition2, windowFirstStage2);
                windowMonsterAnger++;
                Debug.Log("Window increased");
                break;
            case 1 : wallmap.SetTile(windowMonsterPosition1, windowFirstStage1);
                softmap.SetTile(windowMonsterPosition2, windowFirstStage2);
                windowMonsterAnger++;
                break;
            case 2 : wallmap.SetTile(windowMonsterPosition1, windowSecondStage1);
                softmap.SetTile(windowMonsterPosition2, windowSecondStage2);
                windowMonsterAnger++;
                windowCollision.SetActive(true);
                soundSource.Play();
                break;
            case 3 : wallmap.SetTile(windowMonsterPosition1, windowFinalStage1);
                softmap.SetTile(windowMonsterPosition2, windowFinalStage2);
                windowMonsterAnger++;
                windowCollision.SetActive(true);
                soundSource.Play();
                break;
            case 4 : 
                minigameBehavior.EndGame();
                break;
            default:
                Debug.Log("Error");
                windowMonsterAnger = 0;
                throw new ArgumentException("Invalid anger stage");
            
        }
    }

    public void BanishMonster()
    {
        bedMonsterAnger = 0;
        solidmap.SetTile(bedmonsterPosition1, firstStage1);
        solidmap.SetTile(bedmonsterPosition2, firstStage2);
        Debug.Log("Banish monster");
    }

    public void windowBanishMonster()
    {
        windowMonsterAnger = 0;
        wallmap.SetTile(windowMonsterPosition1, windowFirstStage1);
        softmap.SetTile(windowMonsterPosition2, windowFirstStage2);
        Debug.Log("windowBanish monster");
    }
}
