using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pikachu : Plant
{
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Length enemies:" + enemies.Count);
       
        if (checkShoot())
        {
            if (currentTime <= 0)
            {
                currentTime = timeCount;
                Shoot();
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }
    }

    private void Shoot()
    {
        GameObject o = Instantiate(ownedPrefab, spawnPosition.position, Quaternion.identity);
        Bullet b = o.GetComponent<Bullet>();
        b.MyColor = bulletColor;
        b.MyDamage = damage;
    }

    private bool checkShoot()
    {
        foreach (Enemy e in enemies)
        {
            if (e != null)
            {
                return true;
            }
        }

        return false;
    }

    
}
