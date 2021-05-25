using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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

    [SerializeField]
    private bool down;

    public bool Down
    {
        get
        {
            return down;
        }
        set
        {
            down = value;
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

        if (down)
        {
            transform.Translate(Vector2.down * Time.deltaTime * Speed);
        }
        else
        {
            transform.Translate(Vector2.up * Time.deltaTime * Speed);
        }
    }


}
