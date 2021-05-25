using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Card : MonoBehaviour {
    public int number;
    [SerializeField] Sprite _spriteMain;
    [SerializeField] Sprite _spriteUp;
    public bool _change = false;
    private Transform _tranform;
    public SpriteRenderer sR;
    [SerializeField] GameObject _gameManager= null;
    void Start()
    {
        _tranform = transform;
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_change)
        {
            sR.sprite = _spriteMain;
        }
        else
        {
            sR.sprite = _spriteUp;
        }
    }
    private void OnMouseDown()
    {
        if (_gameManager.GetComponent<GameManager>().count == 2) return;
        _change = !_change;
        if (_gameManager.GetComponent<GameManager>().count == 0)
        {
            _gameManager.GetComponent<GameManager>()._card1 = this;
            _gameManager.GetComponent<GameManager>().count++;
        }
        else
        {
            _gameManager.GetComponent<GameManager>()._card2 = this;
            _gameManager.GetComponent<GameManager>().count++;
        }
    }
}
