using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private float timeSpawn;

    private float currentTime;

    [SerializeField]
    private GameObject sharkPrefab;

    [SerializeField]
    private Health myHealth;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private Transform sharkPosition;

    private string[,] stringShark = new string[,]
    {
        { "ALPHA","BETA","CATS","DOGGY","ELEMON","FAKER","GIRLS","HEIGHT","INOE","JACKY","KILLER","LOWLY","MANY","NANONE","OMELY","POPPY","QTV","RENEKT","SILLY","TEEMO"},
        { "ANGRY","BOOTS","COOKIE","DEAL","ELLIE","FEEL","GOOD","HILLS","IEMNSA","JHJKLE","KOOLPA","LILION","MAMAMO","NEWS","ONTIME","PEWPEW","QUATAY","REDDIE","SHARKE","TOMMY"},
        { "ANTOM","BIKES","CRAYON","DATE","ELANOA","FOOLIS","GRILLA","HIGHS","IMPACT","JELISH","KAPPA","LUCKY","MINERS","NATALIE","ORANGE","PAYPAL","QUANQE","REALS","SHITS","TIMERS"}
    };

    void Start()
    {
        currentTime = 1f;
        myHealth.Initialize(maxHealth, maxHealth);
    }

    
    void Update()
    {
        if (currentTime <= 0)
        {
            SpawnShark();
            currentTime = timeSpawn;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }

        if (myHealth.IsDeath)
        {
            Destroy(gameObject);
        }
    }

    void SpawnShark()
    {
        sharkPosition.position = new Vector3(sharkPosition.position.x, UnityEngine.Random.Range(2f,-2f), sharkPosition.position.z);

        GameObject o = Instantiate(sharkPrefab, sharkPosition.position, Quaternion.identity);
        Shark s = o.GetComponent<Shark>();

        int indexX = UnityEngine.Random.Range(0, 3);
        int indexY = UnityEngine.Random.Range(0, 20);

        s.MyString = stringShark[indexX, indexY];
        s.Initilize(true);

        GameManager.MyInstance.Sharks.Add(s);
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Shark")
        {
            Destroy(col.gameObject);
            myHealth.MyCurrentValue -= 10;
        }
    }
}
