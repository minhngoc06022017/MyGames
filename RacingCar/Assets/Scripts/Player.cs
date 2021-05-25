using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private bool doubleCoin;
    public bool DoubleCoin
    {
        get
        {
            return doubleCoin;
        }
        set
        {
            doubleCoin = value;
        }
    }

    public bool canMortal = false;

    [SerializeField]
    private float mortalTime;

    [SerializeField]
    private float mortalCount;

    [SerializeField]
    private bool mortal;

    public bool Mortal
    {
        get
        {
            return mortal;
        }
        set
        {
            mortal = value;
        }
    }

    [SerializeField]
    private Transform spawnPosition;

    [SerializeField]
    private GameObject myBulletPrefab;

    [SerializeField]
    private float speed;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    [SerializeField]
    private float coin;

    public float Coin
    {
        get
        {
            return coin;
        }
        set
        {
            coin = value;
        }
    }

    [SerializeField]
    private float bulletAmount;

    public float BulletAmount
    {
        get
        {
            return bulletAmount;
        }
        set
        {
            bulletAmount = value;
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (mortal)
        {
            if (mortalCount <= mortalTime)
            {
                mortalCount += Time.deltaTime;
            }
            else
            {
                mortal = false;
                anim.SetBool("Mortal", mortal);
                mortalCount = 0;
            }
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.up * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.down * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.left * Time.deltaTime * Speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bulletAmount > 0)
            {
                Instantiate(myBulletPrefab, spawnPosition.position , Quaternion.identity);
                bulletAmount -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!mortal && canMortal)
            {
                mortal = true;
                anim.SetBool("Mortal", mortal);
            }
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        if (collision.gameObject.tag == "Coin")
        {
            if (!DoubleCoin)
            {
                Coin += 1;
            }
            else
            {
                Coin += 1 * 2;
            }

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            if (mortal)
            {
                if (!DoubleCoin)
                {
                    Coin += 5;
                }
                else
                {
                    Coin += 5 * 2;
                }

                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
