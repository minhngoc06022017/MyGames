using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }

    [SerializeField]
    private float timeSpawn;

    [SerializeField]
    private float timeCount;

    [SerializeField]
    private Player player;
    public Player MyPlayer
    {
        get
        {
            return player;
        }
    }

    [SerializeField]
    private Transform[] spawnPosition;

    [SerializeField]
    private GameObject[] myPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCount <= timeSpawn)
        {
            timeCount += Time.deltaTime;
        }
        else
        {
            timeCount = 0;
            int spawn = UnityEngine.Random.Range(2,5);
            int coin = UnityEngine.Random.Range(1,spawn);

            for(int i=0; i<spawn; i++)
            {
                if(coin > 0)
                {
                    GameObject coinO=Instantiate(myPrefab[2], spawnPosition[i].position, Quaternion.identity) as GameObject;
                    Enemy e = coinO.GetComponent<Enemy>();
                    if (i < 2) e.Down = true;
                    coin--;
                }
                else
                {
                    if (i < 2)
                    {
                        Instantiate(myPrefab[1], spawnPosition[i].position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(myPrefab[0], spawnPosition[i].position, Quaternion.identity);
                    }
                }
            }
        }
    }

    public void buyMortal()
    {
        player.canMortal = true;
    }
    public void buyBullet()
    {
        player.BulletAmount += 3;
    }
    public void buyDoubleCoin()
    {
        player.DoubleCoin = true;
    }
}
