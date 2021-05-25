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
    private Transform collectPosition;
    public Transform CollectPosition
    {
        get
        {
            return collectPosition;
        }
    }
    [SerializeField]
    private Transform endSunPosition;
    public Transform EndSunPosition
    {
        get
        {
            return endSunPosition;
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
