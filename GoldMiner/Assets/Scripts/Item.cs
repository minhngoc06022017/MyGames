using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    [SerializeField]
    float weight = 2f;
    public float Weight
    {
        get
        {
            return weight;
        }
    }

    [SerializeField]
    float amount = 700;
    public float Amount
    {
        get
        {
            return amount;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "hook")
        {
            RopeMovement r = col.gameObject.GetComponentInParent<RopeMovement>();
            if (r.moveDown)
            {
                r.moveDown = false;
                r.move_Speed -= weight;
                r.amountTemp = amount;
                Destroy(gameObject);
            }
            
        }
    }
}
