using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rat : MonoBehaviour
{
    [SerializeField]
    private Transform start, end;

    [SerializeField]
    private GameObject itemSprite;

    [SerializeField]
    private Item item;

    [SerializeField]
    private bool moveRight;

    [SerializeField]
    float weight = 2f;

    [SerializeField]
    float amount = 700;

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
        if (item != null)
        {
            itemSprite.SetActive(true);
            itemSprite.GetComponent<SpriteRenderer>().sprite = item.gameObject.GetComponent<SpriteRenderer>().sprite;
            itemSprite.GetComponent<SpriteRenderer>().color = item.gameObject.GetComponent<SpriteRenderer>().color;
        }
    }


    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.down * Time.deltaTime * Speed);
        }
        else
        {
            transform.Translate(Vector2.up * Time.deltaTime * Speed);
        }

        if(transform.position.x >= start.position.x)
        {
            moveRight = false;
        }else if(transform.position.x <= end.position.x)
        {
            moveRight = true;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "hook")
        {
            RopeMovement r = col.gameObject.GetComponentInParent<RopeMovement>();
            if (r.moveDown)
            {
                r.moveDown = false;

                if (item != null)
                {
                    weight += item.Weight / 2;
                    amount += item.Amount;
                }
                r.move_Speed -= weight;
                r.amountTemp = amount;

                Destroy(gameObject);
            }
        }
    }
}
