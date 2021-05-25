using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject listUI;
    public GameObject prefabImage;

    public GameObject[] petPrefabs;
    public Transform[] MyGates;
    public Sprite MySprite;

    public Text winCountText;

    public int index;

    public int winCount;

    public Health MyHealth;
    public float maxHealth;

    public bool PlayerDown;

    void Start()
    {
        MyHealth.Initialize(maxHealth, maxHealth);

        winCountText.text = winCount+"";

        index = 0;
        for (int i = 0; i < 3; i++)
        {
            AddPetUI(i);
        }

        PetUI petUI = listUI.transform.GetChild(0).gameObject.GetComponent<PetUI>();
        petUI.Active();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDown)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                AddNewPet(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                AddNewPet(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                AddNewPet(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                AddNewPet(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                AddNewPet(4);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                AddNewPet(0);
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                AddNewPet(1);
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                AddNewPet(2);
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                AddNewPet(3);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                AddNewPet(4);
            }
        }

        
    }
    public void Intialize()
    {
        MyHealth.Initialize(maxHealth, maxHealth);

        winCountText.text = winCount + "";

        foreach(Transform t in listUI.transform)
        {
            Destroy(t.gameObject);
        }

        index = 0;

        for (int i = 0; i < 3; i++)
        {
            AddPetUI(i);
        }

        PetUI petUI = listUI.transform.GetChild(3).gameObject.GetComponent<PetUI>();
        petUI.Active();

    }

    public void AddNewPet(int position)
    {
        if (listUI.transform.GetChild(0).gameObject.GetComponent<PetUI>().timing.IsFull)
        {

            Destroy(listUI.transform.GetChild(0).gameObject);

            GameObject o=Instantiate(petPrefabs[GameManager.MyInstance.listSpawn[index]], MyGates[position].position, Quaternion.identity) as GameObject;
            o.transform.parent = GameManager.MyInstance.petCollections;

            index++;
            int temp = index + 3;
            AddPetUI(temp);

            PetUI petUI = listUI.transform.GetChild(1).gameObject.GetComponent<PetUI>();
            petUI.Active();
        }

    }
    private void AddPetUI(int index)
    {
        GameObject o1 = Instantiate(prefabImage, listUI.transform) as GameObject;
        int temp = GameManager.MyInstance.listSpawn[index];
        if (temp == 2)
        {
            o1.GetComponent<Image>().color = Color.red;
        }
        if (temp == 3)
        {
            o1.GetComponent<Image>().color = Color.black;
        }
        if (temp == 4)
        {
            o1.GetComponent<Image>().color = Color.yellow;
        }
        if (temp == 1)
        {
            o1.GetComponent<Image>().color = Color.blue;
        }

        o1.GetComponent<Image>().sprite = MySprite;
    }
}
