using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField]
    private Plant myPlant;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            Enemy e = col.gameObject.GetComponent<Enemy>();

            myPlant.MyEnemies.Add(e);
        }
    }
}
