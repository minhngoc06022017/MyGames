using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Image content;

    [SerializeField]
    private float lerpSpeed;

    private float currentFill;


    public float MyMaxValue { get; set; }

    public bool IsDeath
    {
        get
        {
            return content.fillAmount == 0;
        }
    }

    private bool isCount;
    public bool IsCount
    {
        get
        {
            return isCount;
        }
        set
        {
            isCount = value;
        }
    }

    private float currentValue;
    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if (value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }



            currentFill = currentValue / MyMaxValue;


        }
    }
    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>();
        content.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();

    }

    private void HandleBar()
    {
        if (IsCount)
        {
            if (currentFill != content.fillAmount)
            {
                content.fillAmount = Mathf.MoveTowards(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed); //chuyen dong deu
                /*content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);*/// Cang ngay toc do cang giam
            }
        }
    }

    public void Pause()
    {
        IsCount = false;
    }

    public void Initialize(float currentValue, float maxValue)
    {
        if (content == null)
        {
            content = GetComponent<Image>();
        }

        IsCount = true;
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
        content.fillAmount = MyCurrentValue / MyMaxValue;
    }
}
