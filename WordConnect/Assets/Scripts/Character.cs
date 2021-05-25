using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string character;

    [SerializeField]
    private Text text;

    [SerializeField]
    private bool counted;
    public bool Counted
    {
        get
        {
            return counted;
        }
        set
        {
            counted = value;
        }
    }

    void Start()
    {
        text.text = character;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (GameManager.MyInstance.CountC && !counted)
        {
            counted = true;
            GameManager.MyInstance.CharacterList += gameObject.name;
        }
    }
    void OnMouseDown()
    {
        
    }
}
