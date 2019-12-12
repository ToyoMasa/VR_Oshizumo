using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSound : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip Birdvoice;     //環境音鳥の鳴き声
    public AudioClip Wind;
    AudioSource Ringer;
    
    void Start()
    {
        Ringer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;

        if (pos.y >= 2 && !Ringer.isPlaying) {
            Ringer.PlayOneShot(Wind);
            Ringer.PlayOneShot(Birdvoice);
        }
        if (pos.y <= 2)
        {
            Ringer.Stop();
        }



    }
}
