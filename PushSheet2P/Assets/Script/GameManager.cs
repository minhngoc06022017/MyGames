using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject restartCanvas;
    public Text winText;

    public Transform petCollections;

    public int[] listSpawn = new int[100];

    private bool checkDeath;

    public Player P1;
    public Player P2;

    void Awake()
    {
        for(int i = 0; i < listSpawn.Length; i++)
        {
            int temp = Random.Range(0,5);
            listSpawn[i] = temp;
        }
    }

    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (P1.MyHealth.IsDeath || P2.MyHealth.IsDeath)
        {
            if (!checkDeath)
            {
                if (P1.MyHealth.IsDeath)
                {
                    P2.winCount++;
                    winText.text = "Player 2 Win\n";
                }
                else
                {
                    P1.winCount++;
                    winText.text = "Player 1 Win\n";
                }

                winText.text += "P1 " + P1.winCount + ":" + P2.winCount + " P2";

                Time.timeScale = 0f;

                restartCanvas.SetActive(true);
                checkDeath = true;
            }

        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;

        restartCanvas.SetActive(false);

        foreach (Transform t in petCollections)
        {
            Destroy(t.gameObject);
        }

        P1.Intialize();
        P2.Intialize();


        checkDeath = false;

    }

    public void DestroyHome(string tag,float value)
    {
        if (P1.gameObject.tag == tag)
        {
            P1.MyHealth.MyCurrentValue -= value;
        }
        else if(P2.gameObject.tag == tag)
        {
            P2.MyHealth.MyCurrentValue -= value;
        }
    }

    
}
