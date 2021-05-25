using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
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
    private GameObject[] cards;

    private List<int> usedCards = new List<int>();

    [SerializeField]
    private GameObject parentCard;

    private GameObject currentCard;

    [SerializeField]
    private int hintCount;
    public int HintCount
    {
        get
        {
            return hintCount;
        }
        set
        {
            hintCount = value;
        }
    }

    [SerializeField]
    private Button hintBtn;

    [SerializeField]
    private Text pointText;
    [SerializeField]
    private Text hintText;
    [SerializeField]
    private GameObject winText;
    [SerializeField]
    private GameObject loseText;

    private float point;

    private float length;

    [SerializeField]
    private Timing timing;

    [SerializeField]
    private float maxTime;

    void Awake()
    {
        length = cards.Length;
    }

    void Start()
    {
        if (length > 0)
        {
            GameObject o= Instantiate(cards[0]) as GameObject;
            currentCard = o;
            o.transform.parent = parentCard.transform;
            usedCards.Add(0);

            timing.Initialize(maxTime, maxTime);
            length--;
        }
        pointText.text="0";
        hintText.text = hintCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!timing.IsFull)
        {
            timing.MyCurrentValue -= Time.deltaTime;
        }
        else
        {
            loseText.SetActive(true);
            parentCard.SetActive(false);
        }
    }
    public void NextMap(int size)
    {
        currentCard = null;

        timing.Pause();

        point += 200 + size * 50 + timing.MyCurrentValue * 5;
        pointText.text= point.ToString();

        Debug.Log(length + "");

        if (length > 0)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (!usedCards.Contains(i))
                {
                    length--;
                    GameObject o = Instantiate(cards[i]) as GameObject;
                    currentCard = o;
                    o.transform.parent=parentCard.transform;
                    usedCards.Add(i);


                    timing.Reset();
                    timing.Initialize(maxTime, maxTime);
                    break;
                }
                
            }
        }
        else
        {
            winText.SetActive(true);
        }
    }

    public void OnHint()
    {
        if (hintCount > 0)
        {
            Card c = currentCard.GetComponent<Card>();

            if (!c.IsFull)
            {
                for (int i = 0; i < c.MyPoints.Length; i++)
                {
                    if (!c.MyPoints[i].isClick)
                    {
                        c.MyPoints[i].gameObject.GetComponent<Button>().onClick.Invoke();
                        hintCount--;
                        hintText.text = hintCount.ToString();
                        break;
                    }
                }
            }
        }
    }

   
}
