using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turtle : Plant
{
    protected override void Start()
    {
        base.Start();

        currentTime = timeCount;
    }

    [SerializeField]
    private bool IsActive;

    [SerializeField]
    private Sprite[] mySprites;

    // Update is called once per frame
    void Update()
    {
        if(currentTime <= 0)
        {
            IsActive = true;
            GetComponent<SpriteRenderer>().sprite = mySprites[1];
        }
        else
        {
            currentTime -= Time.deltaTime;
        }

        if(currentTime > 0f && currentTime < 3.5f)
        {
            GetComponent<SpriteRenderer>().sprite = mySprites[0];
        }

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Enemy")
        {
            if (IsActive)
            {
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
