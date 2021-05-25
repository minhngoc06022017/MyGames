using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    
    private Transform collectPosition;
    private Transform endPosition;

    [SerializeField]
    private bool moveDown;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float collectSpeed;
    [SerializeField]
    private bool collect;

    [SerializeField]
    private float timeCount;

    void Start()
    {
        collectPosition = GameManager.MyInstance.CollectPosition;
        endPosition = GameManager.MyInstance.EndSunPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!collect)
        {
            if (moveDown)
            {
                transform.Translate(Vector2.down * Time.deltaTime * Speed);

                if (transform.position.y <= endPosition.position.y) moveDown = false;
            }

            if (timeCount >= 0f)
            {
                timeCount -= Time.deltaTime;
            }
            else
            {
                collect = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, collectPosition.position , collectSpeed*Time.deltaTime);

            if(transform.position == collectPosition.position)
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnMouseOver()
    {
        if (!collect && HandScript.MyInstance.IsEmpty)
        {
            collect = true;
            Debug.Log("Add money");
        }
    }
}
