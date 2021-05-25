using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringElement : MonoBehaviour
{
    [SerializeField]
    private string stringComplete;
    public string StringComplete
    {
        get
        {
            return stringComplete;
        }

    }

    private bool isComplete;
    public bool IsComplete
    {
        get
        {
            return isComplete;
        }
        set
        {
            isComplete = value;
        }
    }

    [SerializeField]
    private ButtonCharacter[] buttons;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void ActiveButtons()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            if (!buttons[i].IsActive)
            {
                buttons[i].Active();
            }
        }

        isComplete = true;
    }
}
