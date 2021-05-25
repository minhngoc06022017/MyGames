using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMoving : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float MyValue;

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
        if (down)
        {
            transform.Translate(Vector2.down * Time.deltaTime * Speed);
        }
        else
        {
            transform.Translate(Vector2.up * Time.deltaTime * Speed);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Home1" || collision.gameObject.name == "Home2")
        {
            GameManager.MyInstance.DestroyHome(collision.gameObject.tag, MyValue);

            Destroy(gameObject);
        }
    }
}
