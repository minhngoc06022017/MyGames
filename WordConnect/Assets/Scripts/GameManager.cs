using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField]
    private Character[] characterObjects;

    [SerializeField]
    private StringElement[] stringList;

    private bool isClearMap
    {
        get
        {
            for (int i = 0; i < stringList.Length; i++)
            {
                if (!stringList[i].IsComplete)
                {
                    return false;
                }
            }
            return true;
        }
    }

    private string characterList;
    public string CharacterList
    {
        get
        {
            return characterList;
        }
        set
        {
            characterList = value;
        }
    }

    private bool countC;
    public bool CountC
    {
        get
        {
            return countC;
        }
    }

    void Start()
    {
        characterList = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            countC = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(characterList);
            countC = false;
            if (!characterList.Equals(""))
            {
                checkString(characterList);

                if (isClearMap)
                {
                    Debug.Log("Win");
                }

                DeActive();
            }
            characterList = "";
        }
    }

    void DeActive()
    {
        for(int i = 0; i < 4; i++)
        {
            if (characterObjects[i].Counted)
            {
                characterObjects[i].Counted = false;
                Debug.Log(characterObjects[i].Counted);
            }
        }
    }

    void checkString(string check)
    {
        for(int i = 0; i < stringList.Length; i++)
        {
            if (stringList[i].StringComplete.Equals(check))
            {
                stringList[i].ActiveButtons();
                break;
            }
        }
    }
}
