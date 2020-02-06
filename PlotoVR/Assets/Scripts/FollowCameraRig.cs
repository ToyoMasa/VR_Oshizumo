using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraRig : MonoBehaviour
{
    public Transform FollowTransform;
    public float FollowValue = 1.0f;

    void Start()
    {

    }

    void Update()
    {
        Vector3 FollowPos = FollowTransform.localPosition * FollowValue;
        FollowPos.y = -0.5f;

        transform.localPosition = FollowPos;
    }
}
