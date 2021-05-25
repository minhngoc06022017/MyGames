using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    private List<EnemyMovement> enemies;
    public List<EnemyMovement> MyEnemies
    {
        get
        {
            return enemies;
        }
        set
        {
            enemies = value;
        }
    }

    private Grid myGrid;
    public Grid MyGrid
    {
        get
        {
            return myGrid;
        }
        set
        {
            myGrid = value;
        }
    }

    private EnemyMovement currentEnemy;
    public EnemyMovement MyCurrentEnemy
    {
        get
        {
            return currentEnemy;
        }
        set
        {
            currentEnemy = value;
        }
    }

    [SerializeField]
    private GameObject MyEvolve;
    [SerializeField]
    private string myName;
    public string MyName
    {
        get
        {
            return myName;
        }
    }

    [SerializeField]
    private Color bulletColor;

    [SerializeField]
    private float dame;
    [SerializeField]
    private float arrange;

    [SerializeField]
    private float timeSpawn;
    [SerializeField]
    private float timeCurrent;

    [SerializeField]
    private Transform positionSpawn;
    [SerializeField]
    private GameObject bulletPrefab;


    void Start()
    {
        enemies = new List<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemy == null)
        {
            if(GameManager.MyInstance.MyEnemies.Count > 0)
            {
                foreach(EnemyMovement e in GameManager.MyInstance.MyEnemies)
                {
                    float distance = Vector3.Distance(transform.position, e.gameObject.transform.position);
                    if (distance < arrange)
                    {
                        currentEnemy = e;
                    }
                }
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, currentEnemy.gameObject.transform.position) >= arrange)
            {
                currentEnemy = null;
            }
        }

        if (timeCurrent <= 0)
        {
            timeCurrent = timeSpawn;

            Spawn();
        }
        else
        {
            timeCurrent -= Time.deltaTime;
        }
    }

    private void Spawn()
    {
        if (currentEnemy != null)
        {
            GameObject o=Instantiate(bulletPrefab, positionSpawn.position, Quaternion.identity);
            Bullet b = o.GetComponent<Bullet>();
            b.MyTarget = currentEnemy;
            b.MyDame = dame;
            o.GetComponent<SpriteRenderer>().color = bulletColor;
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("MOuse");

        if (HandScript.MyInstance.MyItem != null)
        {
            if (HandScript.MyInstance.MyItem.MyName == myName)
            {
                Debug.Log("Merge");
                GameObject o = Instantiate(MyEvolve, myGrid.transform.position, Quaternion.identity);
                Pet p = o.GetComponent<Pet>();
                p.MyGrid = myGrid;
                myGrid.MyItem = p;

                Destroy(gameObject);

                HandScript.MyInstance.MyItem = null;
            }
            else
            {
                Debug.Log("Swap");

                Pet swapPet = HandScript.MyInstance.MyItem;

                myGrid.MyItem = null;
                myGrid.AddItem();

                myGrid = swapPet.MyGrid;
                myGrid.MyItem = this;
                transform.position = myGrid.gameObject.transform.position;

                

            }
        }
        else
        {
            for (int i = 0; i < GameManager.MyInstance.MyAnimalPrefabs.Length; i++)
            {
                Pet p = GameManager.MyInstance.MyAnimalPrefabs[i].GetComponent<Pet>();

                if (p.MyName.Equals(myName))
                {
                    HandScript.MyInstance.MyItem = p;
                    HandScript.MyInstance.MyItem.MyGrid = myGrid;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
