using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    protected List<Enemy> enemies;
    public List<Enemy> MyEnemies
    {
        get
        {
            return enemies;
        }
        set
        {
            enemies = value;
        }
    }

    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float maxHealth;
    protected float currentHealth;

    [SerializeField]
    protected Color bulletColor;

    [SerializeField]
    protected float timeCount;
    [SerializeField]
    protected float currentTime;

    [SerializeField]
    protected GameObject ownedPrefab;
    [SerializeField]
    protected Transform spawnPosition;

    protected virtual void Start()
    {
        enemies = new List<Enemy>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void TakeDame(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        StartCoroutine(TakeDameEffect());
    }

    protected IEnumerator TakeDameEffect()
    {
        GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(0.5f);

        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
