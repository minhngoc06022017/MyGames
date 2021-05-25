using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Character : MonoBehaviour
{
    [SerializeField]
    private string characterTarget;
    public string CharacterTarget
    {
        get
        {
            return characterTarget;
        }
        set
        {
            characterTarget = value;
        }
    }

    [SerializeField]
    private Text textC;

    void Start()
    {
        textC.text = characterTarget;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Active()
    {
        textC.color = Color.red;
    }
    public void DeActive()
    {
        textC.color = Color.black;
    }
}
