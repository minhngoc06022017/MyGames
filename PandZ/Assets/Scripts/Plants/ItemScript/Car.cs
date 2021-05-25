using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private Transform endPosiion;

    [SerializeField]
    private bool run;

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
        if (run)
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
        }

        if(transform.position.x >= endPosiion.position.x)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            if (!run) run = true;

            Destroy(col.gameObject);
        }
    }
}
