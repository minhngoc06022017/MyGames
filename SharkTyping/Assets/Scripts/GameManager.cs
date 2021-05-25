using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private string correctCharacter = "QWERTYUIOPASDFGHJKLZXCVBNM";

    private string[,] stringShark = new string[,]
    {
        { "ALPHA","BETA","CATS","DOGGY","ELEMON","FAKER","GIRLS","HEIGHT","INOE","JACKY","KILLER","LOWLY","MANY","NANONE","OMELY","POPPY","QTV","RENEKT","SILLY","TEEMO"},
        { "ANGRY","BOOTS","COOKIE","DEAL","ELLIE","FEEL","GOOD","HILLS","IEMNSA","JHJKLE","KOOLPA","LILION","MAMAMO","NEWS","ONTIME","PEWPEW","QUATAY","REDDIE","SHARKE","TOMMY"},
        { "ANTOM","BIKES","CRAYON","DATE","ELANOA","FOOLIS","GRILLA","HIGHS","IMPACT","JELISH","KAPPA","LUCKY","MINERS","NATALIE","ORANGE","PAYPAL","QUANQE","REALS","SHITS","TIMERS"}
    };


    private bool startCount;

    [SerializeField]
    private GameObject sharkPrefab;

    [SerializeField]
    private Transform sharkPosition;

    private int turn;

    private float time;

    private int numberShark;

    private Shark currentShark;

    private List<Shark> sharks;
    public List<Shark> Sharks
    {
        get
        {
            return sharks;
        }
        set
        {
            sharks = value;
        }
    }

    void Start()
    {
        sharks = new List<Shark>();

        //StartCoroutine(callShark());
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        //Debug.Log(time);

        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                //Debug.Log("KeyCode down: " + kcode);
                string c = kcode + "";
                if (correctCharacter.Contains(c))
                {
                    //Debug.Log("KeyCode down: " + kcode);
                    if (!startCount)
                    {
                        startCount = true;
                        checkShark(c);
                    }
                    else
                    {
                        attackShark(c);
                    }
                }
                else if (c.Equals("Backspace"))
                {
                    currentShark.DeleteTarget();
                    currentShark = null;
                    startCount = false;
                }
                
            }
                
        }
    }

    void checkShark(string c)
    {
        foreach(Shark s in sharks)
        {
            if (s.FirstCharacter.Equals(c))
            {
                currentShark = s;
                s.getHurt();
                break;
            }
        }
    }
    void attackShark(string c)
    {
        if (currentShark != null)
        {
            if (currentShark.check(c))
            {
                currentShark.getHurt();
                if (currentShark.IsDie)
                {
                    sharks.Remove(currentShark);

                    if (currentShark.IsSharkBoss)
                    {
                        currentShark.MoveRight = true;
                        currentShark.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    else
                    {
                        Destroy(currentShark.gameObject);
                    }
                    
                    currentShark = null;
                    startCount = false;
                }
            }
        }
    }
    IEnumerator callShark()
    {
        numberShark = UnityEngine.Random.Range(8,13);

        List<int> temp = new List<int>();

        int OLO = 10;

        for (int i = 0; i < numberShark; i++)
        {
            sharkPosition.position = new Vector3(sharkPosition.position.x,UnityEngine.Random.Range(6f,-6f), sharkPosition.position.z);

            GameObject o = Instantiate(sharkPrefab, sharkPosition.position , Quaternion.identity);
            
            SpriteRenderer sr = o.GetComponent<SpriteRenderer>();
            sr.sortingOrder = OLO;
            OLO++;
            
            Shark s = o.GetComponent<Shark>();

            int indexX = UnityEngine.Random.Range(0,3);
            int indexY = UnityEngine.Random.Range(0,20);

            if (temp != null)
            {
                if (temp.Contains(indexY))
                {
                    while (true)
                    {
                        indexY = UnityEngine.Random.Range(0, 20);
                        if (!temp.Contains(indexY)) break;
                    }
                }
            }

            temp.Add(indexY);



            s.MyString = stringShark[indexX,indexY];
            s.Initilize(false);

            sharks.Add(s);

            yield return new WaitForSeconds(1.5f);
        }
    }
}
