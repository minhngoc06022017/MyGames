using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigMouth : Plant
{
    protected override void Start()
    {
        base.Start();
    }

    [SerializeField]
    private bool IsEat;
    [SerializeField]
    private Sprite mySprite;
    [SerializeField]
    private SpriteRenderer eatImg;

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            IsEat = false;
        }

        if (IsEat)
        {
            eatImg.sprite = mySprite;
        }
        else
        {
            eatImg.sprite = null;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            if (!IsEat)
            {
                Destroy(col.gameObject);
                currentTime = timeCount;
                IsEat = true;
            }
        }
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            if (!IsEat)
            {
                Destroy(col.gameObject);
                currentTime = timeCount;
                IsEat = true;
            }
        }
    }
}
