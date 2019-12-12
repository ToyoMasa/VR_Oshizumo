using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDestroy : MonoBehaviour
{
    public float DestroyTime = 1.0f;

    float Timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Timer = DestroyTime;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
