using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
