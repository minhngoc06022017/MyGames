using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : Plant
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
            SpawnSun();
        }else
        {
            currentTime -= Time.deltaTime;
        }
    }

    private void SpawnSun()
    {
        Instantiate(ownedPrefab, spawnPosition.position, Quaternion.identity);
    }
}
