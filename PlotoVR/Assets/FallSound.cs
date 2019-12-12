using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip Wind;     //落下中の風
    AudioSource FallRinger;
    void Start()
    {
        FallRinger = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;

        if (pos.y <= 2 && pos.y>=-50&&!FallRinger.isPlaying)
        {
            //Ringer.PlayOneShot(Wind);
            FallRinger.PlayOneShot(Wind);
        }
        if (pos.y <= -50 || pos.y >= 2)
        {
            FallRinger.Stop();
        }
    }
}
