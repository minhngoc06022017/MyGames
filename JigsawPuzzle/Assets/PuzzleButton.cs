using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleButton : MonoBehaviour
{
    public GameObject startPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPuzzlePhoto(Image Photo)
    {
        for(int i = 0; i < 36; i++)
        {
            GameObject.Find("Pieces_" + i).transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite=Photo.sprite; 
        }

        startPanel.SetActive(false);
    }
}
