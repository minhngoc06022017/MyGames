using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCharacter : MonoBehaviour
{
    [SerializeField]
    private Text textCharacter;

    [SerializeField]
    private string c;

    private bool isActive;
    public bool IsActive
    {
        get
        {
            return isActive;
        }
        set
        {
            isActive = value;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Active()
    {
        isActive = true;
        textCharacter.enabled = true;
        textCharacter.text = c;
    }
}
