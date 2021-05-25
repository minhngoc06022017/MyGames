using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigBu : Plant
{
    [SerializeField]
    private Sprite[] mySprites;

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        if(currentHealth <= maxHealth * 0.7f && currentHealth > maxHealth * 0.3f)
        {
            GetComponent<SpriteRenderer>().sprite = mySprites[0];
        }else if(currentHealth <= maxHealth * 0.3f)
        {
            GetComponent<SpriteRenderer>().sprite = mySprites[1];
        }
    }
}
