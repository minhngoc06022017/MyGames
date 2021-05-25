using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private List<EnemyMovement> enemies;
    public List<EnemyMovement> MyEnemies
    {
        get
        {
            return enemies;
        }
    }

    [SerializeField]
    private float timeCount;
    [SerializeField]
    private float timeCurrent;

    [SerializeField]
    private GameObject bossPrefab;
    [SerializeField]
    private Transform positionSpawn;

    [SerializeField]
    private GameObject[] animalPrefabs;
    public GameObject[] MyAnimalPrefabs
    {
        get
        {
            return animalPrefabs;
        }
    }
    [SerializeField]
    private GameObject[] myGrids;
    public GameObject[] MyGrids
    {
        get
        {
            return myGrids;
        }
    }
    [SerializeField]
    private Transform[] enemyPoints;
    public Transform[] MyEnemyPoints
    {
        get
        {
            return enemyPoints;
        }
    }

    void Start()
    {
        enemies = new List<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCurrent <= 0)
        {
            timeCurrent = timeCount;

            GameObject o = Instantiate(bossPrefab, positionSpawn.position, Quaternion.identity);
            EnemyMovement e = o.GetComponent<EnemyMovement>();
            e.MyPoints = enemyPoints;

            enemies.Add(e);
        }
        else
        {
            timeCurrent -= Time.deltaTime;
        }

        Debug.Log(enemies.Count);
    }

    public void addAnimal()
    {
        if (!checkFull() && HandScript.MyInstance.MyItem==null)
        {
            HandScript.MyInstance.MyItem = animalPrefabs[0].GetComponent<Pet>();
        }
    }

    public bool checkFull()
    {
        for(int i = 0; i < myGrids.Length; i++)
        {
            Grid g = myGrids[i].GetComponent<Grid>();
            if (g.IsEmpty)
            {
                return false;
            }
        }

        return true;
    }
}
