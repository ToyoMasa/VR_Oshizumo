using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterSounde : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip Water ;     //水中呼吸音
    public AudioClip Wave  ;
    public AudioClip Landing ;
    AudioSource UnderWaterRinger;
    AudioSource InWaterRinger;
    void Start()
    {
        UnderWaterRinger = GetComponent<AudioSource>();
        InWaterRinger = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        if ( pos.y <= -50 && !UnderWaterRinger.isPlaying)
        {
            UnderWaterRinger.PlayOneShot(Water);
            UnderWaterRinger.PlayOneShot(Wave);
        }
        if (pos.y <= -50 && pos.y>=-55 && !InWaterRinger.isPlaying)
        {
            InWaterRinger.PlayOneShot(Landing);
        }
        if(pos.y >= -50 && pos.y <= -60)
        {
            InWaterRinger.Stop();
        }

            if (pos.y >= -60)
        {
            UnderWaterRinger.Stop();
        }
    }
}
