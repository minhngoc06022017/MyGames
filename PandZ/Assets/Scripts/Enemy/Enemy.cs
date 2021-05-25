using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float currentHealth;

    [SerializeField]
    private float damage;

    [SerializeField]
    private float maxSpeed;
    private float slowSpeed;
    private float currentSpeed;

    [SerializeField]
    private float timeSlowCount;
    [SerializeField]
    private float currentSlowTime;

    [SerializeField]
    private float timeAttackCount;
    [SerializeField]
    private float currentAttackTime;

    private Plant myCurrentEnemy;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (slowSpeed > 0)
        {
            if (currentSlowTime <= 0)
            {
                slowSpeed = 0;
            }
            else
            {
                currentSlowTime -= Time.deltaTime;
            }
        }

        currentSpeed = maxSpeed - slowSpeed;

        Debug.Log("Enemy speed:" + currentSpeed);

        if (myCurrentEnemy == null)
        {
            transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        }
        else
        {
            if (currentAttackTime <= 0)
            {
                currentAttackTime = timeAttackCount;
                myCurrentEnemy.TakeDame(damage);
            }
            else
            {
                currentAttackTime -= Time.deltaTime;
            }
        }
    }

    public void TakeDame(float damage,bool isSlow,float slowDamage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (isSlow)
        {
            slowSpeed = slowDamage;
            currentSlowTime = timeSlowCount;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Plant")
        {
            Plant p = col.gameObject.GetComponent<Plant>();

            myCurrentEnemy = p;
        }
    }
}
