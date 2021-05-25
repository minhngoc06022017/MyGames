using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private EnemyMovement myTarget;
    public EnemyMovement MyTarget
    {
        get
        {
            return myTarget;
        }
        set
        {
            myTarget = value;
        }
    }

    [SerializeField]
    private float speed;

    [SerializeField]
    private float dame;
    public float MyDame
    {
        get
        {
            return dame;
        }
        set
        {
            dame = value;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myTarget != null)
        {
            Vector3 enemyPosition = myTarget.gameObject.GetComponent<Transform>().position;
            transform.position = Vector3.MoveTowards(transform.position, enemyPosition, speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
