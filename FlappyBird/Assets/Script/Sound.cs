using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource adis;
    public AudioClip flying, getPoint;
    void Start()
    {
        adis = gameObject.GetComponent<AudioSource>();
        flying = Resources.Load<AudioClip>("Flying");
        getPoint = Resources.Load<AudioClip>("Coins");
    }

    // Update is called once per frame
    public void playSound(string path)
    {
        switch (path)
        {
            case "flying":
                adis.clip = flying;
                adis.PlayOneShot(flying, 0.8f);
                break;
            case "point":
                adis.clip = getPoint;
                adis.PlayOneShot(getPoint, 0.8f);
                break;
        }
    }
}
