using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swan : Plant
{
    [SerializeField]
    private float slowDame;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
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
        b.IsSlow = true;
        b.SlowDamage = slowDame;
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
