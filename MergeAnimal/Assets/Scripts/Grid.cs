using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private Pet myItem;
    public Pet MyItem
    {
        get
        {
            return myItem;
        }
        set
        {
            myItem = value;
        }
    }

    public bool IsEmpty
    {
        get
        {
            if (myItem == null)
            {
                return true;
            }
            return false;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        AddItem();
    }
    public void AddItem()
    {
        if (IsEmpty)
        {
            if (HandScript.MyInstance.MyItem != null)
            {
                for (int i = 0; i < GameManager.MyInstance.MyAnimalPrefabs.Length; i++)
                {
                    Pet p = GameManager.MyInstance.MyAnimalPrefabs[i].GetComponent<Pet>();

                    if (p.MyName.Equals(HandScript.MyInstance.MyItem.MyName))
                    {
                        GameObject o = Instantiate(GameManager.MyInstance.MyAnimalPrefabs[i], transform.position, Quaternion.identity);
                        Pet myPet = o.GetComponent<Pet>();
                        myPet.MyGrid = this;
                        myItem = myPet;
                        break;
                    }
                }
                HandScript.MyInstance.MyItem = null;
            }
        }
    }
}
