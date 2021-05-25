using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private int spriteIndex;
    private SpriteRenderer mySpriteRenderer;

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private Health myHealth;
    public Health MyHealth
    {
        get
        {
            return myHealth;
        }
        set
        {
            myHealth = value;
        }

    }

    [SerializeField]
    private Transform[] Points;
    public Transform[] MyPoints
    {
        get
        {
            return Points;
        }
        set
        {
            Points = value;
        }
    }

    [SerializeField]
    private float speed;

    private int index;

    [SerializeField]
    private bool run;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.sprite = sprites[spriteIndex];

        myHealth.Initialize(maxHealth, maxHealth);
    }

    
    void Update()
    {
        if (run)
        {
            Vector3 temp = Points[index].position;

            if(transform.position.y < temp.y)
            {
                spriteIndex = 0;
            }else if(transform.position.x < temp.x)
            {
                spriteIndex = 1;
            }else if(transform.position.y > temp.y)
            {
                spriteIndex = 2;
            }

            mySpriteRenderer.sprite = sprites[spriteIndex];

            transform.position = Vector3.MoveTowards(transform.position, temp, speed * Time.deltaTime);

            if (transform.position == temp)
            {
                index++;
            }

            if (index == Points.Length)
            {
                run = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Bullet")
        {
            myHealth.MyCurrentValue -= col.gameObject.GetComponent<Bullet>().MyDame;
            Destroy(col.gameObject);

            if (myHealth.MyCurrentValue == 0)
            {
                GameManager.MyInstance.MyEnemies.Remove(this);
                Destroy(gameObject);
            }
        }
    }
}
