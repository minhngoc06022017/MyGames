using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private float myDamage;
    public float MyDamage
    {
        get
        {
            return myDamage;
        }
        set
        {
            myDamage = value;
        }
    }

    private float slowDamage;
    public float SlowDamage
    {
        get
        {
            return slowDamage;
        }
        set
        {
            slowDamage = value;
        }
    }

    private bool isSlow;
    public bool IsSlow
    {
        get
        {
            return isSlow;
        }
        set
        {
            isSlow = value;
        }
    }

    private Color myColor;
    public Color MyColor
    {
        get
        {
            return myColor;
        }
        set
        {
            myColor = value;
        }
    }

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
    void Start()
    {
        GetComponent<SpriteRenderer>().color = myColor;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * Speed);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            Enemy e = col.gameObject.GetComponent<Enemy>();

            if (isSlow)
            {
                e.TakeDame(myDamage, true, slowDamage);
            }
            else
            {
                e.TakeDame(myDamage, false, 0);
            }

            Destroy(gameObject);
        }
    }
}
