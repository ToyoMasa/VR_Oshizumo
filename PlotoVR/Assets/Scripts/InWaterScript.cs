using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class InWaterScript : MonoBehaviour
{
    public Transform Target;

    ColorGradingComponent ColorGrading;
    PostProcessingContext Post;

    // Start is called before the first frame update
    void Start()
    {
        ColorGrading = GetComponent<ColorGradingComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
