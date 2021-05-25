using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Card _card1,_card2;
    public int count;
    private float _stopTime=1f;
    private float _countStopTime=0;

    [SerializeField] int columm;
    [SerializeField] int row;
    [SerializeField] Transform _firstPosition = null; 
    [SerializeField] Card[] _listCards = null;
    void Start()
    {
        count = 0;
        _checkCR();
        int setCard = (row * columm) / 2;
        
        int countPosition=0;
        //Debug.Log(row);
        //Debug.Log(columm);

        Card[] _tempCard = new Card[setCard];
        for(int i = 0; i < _tempCard.Length; i++)
        {
            _tempCard[i] = _listCards[Random.Range(0,5)];
            //Debug.Log(_tempCard[i]);
        }
        Card[] _tempCard2 = new Card[setCard*2];
        for (int i = 0; i < _tempCard.Length; i++)
        {
            
            while (true)
                {
                    int index = Random.Range(0, (setCard*2) -1);
                    Debug.Log(index);
                    if (_tempCard2[index] == null)
                    {
                        _tempCard2[index] = _tempCard[i];
                        Debug.Log(_tempCard2[index]);
                        break;
                    }
                }
        }
        int tempCount = 0;
        for(int i = 0; i < _tempCard2.Length; i++)
        {
            if (_tempCard2[i] == null)
            {
                _tempCard2[i] = _tempCard[tempCount];
                tempCount++;
            }
        }



        int height = 0;
        for (int i = 0; i < row; i++)
        {
            int width = 0;
            for(int j = 0; j < columm; j++)
            {
                
                Instantiate(_tempCard2[countPosition],new Vector2(_firstPosition.position.x + width*5f,_firstPosition.position.y - height*5f),Quaternion.identity);
                //Debug.Log(countPosition);
                width++;
                countPosition++;
            }
            height++;
            
        }
        
    }
    private void _checkCR()
    {
        if (row > 2) row = 2;
        if (row <= 1)
        {
            row = 1;
            if (columm < 1)
            {
                columm = 1;
            }
            if (columm > 7)
            {
                columm = 7;
            }
            if(columm%2==1 && columm < 7)
            {
                columm +=1;
            }
            if(columm % 2 == 1 && columm >= 7)
            {
                columm = 6;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(_card1!=null && _card2 != null)
        {
            if(_countStopTime < _stopTime)
            {
                _countStopTime += Time.deltaTime;
            }
            else
            {
                _checkCard();
                _countStopTime = 0;
            }
            
        }
    }
    private void _checkCard()
    {
        count = 0;
        if (_card1.number == _card2.number)
        {
            Destroy(_card1.gameObject);
            Destroy(_card2.gameObject);

        }
        else
        {
            _card1._change = false;
            _card2._change = false;

            _card1 = null;
            _card2 = null;
        }
    }
    
}
