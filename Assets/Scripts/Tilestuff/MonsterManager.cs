using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "MonsterManager", menuName = "MonsterManager")]
public class MonsterManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;
    [SerializeField]
    private TileBase firstStage;
    [SerializeField]
    private TileBase secondStage;
    [SerializeField]
    private TileBase finalStage;
    [SerializeField]
    private Vector3Int bedmonsterPosition = new Vector3Int(0, 2, 0);

    [SerializeField] private float angerInterval = 20;
    
    [SerializeField]
    private float angerTimer = 20;
    
    
    [SerializeField]
    private byte bedMonsterAnger = 1;
    
    
    internal void Update()
    {
        angerTimer -= Time.deltaTime;
        if (angerTimer <= 0)
        {
            increaseAngerStage();
            angerTimer = angerInterval;
        }
    }

    public void increaseAngerStage()
    {
        switch (bedMonsterAnger)
        {
            case 0 : map.SetTile(bedmonsterPosition, firstStage);
                bedMonsterAnger++;
                break;
            case 1 : map.SetTile(bedmonsterPosition, firstStage); 
                bedMonsterAnger++;
                break;
            case 2 : map.SetTile(bedmonsterPosition, secondStage);
                bedMonsterAnger++;
                break;
            case 3 : map.SetTile(bedmonsterPosition, finalStage);
                break;
            default:
                Debug.Log("Error");
                bedMonsterAnger = 0;
                throw new ArgumentException("Invalid anger stage");
            
        }
    }

    public void BanishMonster()
    {
        bedMonsterAnger = 0;
        map.SetTile(bedmonsterPosition, firstStage);
        Debug.Log("Banish monster");
    }
}
