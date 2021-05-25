using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public GameObject[] Strings;

    public string MyString;

    private int myHealth;
    private int myInitialHealth;

    private int index;

    [SerializeField]
    private bool moveRight;
    public bool MoveRight
    {
        get
        {
            return moveRight;
        }
        set
        {
            moveRight = true;
        }
    }

    [SerializeField]
    private bool isSharkBoss;
    public bool IsSharkBoss
    {
        get
        {
            return isSharkBoss;
        }
        set
        {
            isSharkBoss = true;
        }
    }

    [SerializeField]
    private float speed;
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    private string firstCharacter;
    public string FirstCharacter
    {
        get
        {
            return firstCharacter;
        }
        set
        {
            firstCharacter = value;
        }
    }
    public bool IsDie
    {
        get
        {
            if (myHealth <= 0)
            {
                return true;
            }

            return false;
        }
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * Speed);
        }
    }

    public void getHurt()
    {
        Strings[index].GetComponent<Character>().Active();
        index++;
        myHealth--;
    }
    public bool check(string c)
    {
        if (Strings[index].GetComponent<Character>().CharacterTarget.Equals(c))
        {
            return true;
        }

        return false;
    }

    public void DeleteTarget()
    {
        index = 0;
        myHealth = myInitialHealth;

        for (int i=0; i< MyString.Length; i++)
        {
            Strings[i].GetComponent<Character>().DeActive();
        }
    }

    public void Initilize(bool isBoss)
    {
        if(MyString.Length > 0)
        {
            index = 0;
            myInitialHealth = MyString.Length;
            myHealth = myInitialHealth;
            FirstCharacter = MyString[0] + "";
            isSharkBoss = isBoss;

            for (int i = 0; i < MyString.Length; i++)
            {
                Strings[i].SetActive(true);
                Strings[i].GetComponent<Character>().CharacterTarget = MyString[i] + "";
            }
        }
    }
}
