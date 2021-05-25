using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : Plant
{
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
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

    private void Shoot()
    {
        GameObject o = Instantiate(ownedPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
