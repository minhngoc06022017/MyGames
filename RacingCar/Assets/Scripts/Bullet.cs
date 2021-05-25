using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float timeLive;
    [SerializeField]
    private float timeCount;

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

    }


    void Update()
    {
        if (timeCount >= timeLive)
        {
            Destroy(gameObject);
        }
        else
        {
            timeCount += Time.deltaTime;
        }


        transform.Translate(Vector2.up * Time.deltaTime * Speed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!GameManager.Instance.MyPlayer.DoubleCoin)
            {
                GameManager.Instance.MyPlayer.Coin += 5;
            }
            else
            {
                GameManager.Instance.MyPlayer.Coin += 5 * 2;
            }


            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
