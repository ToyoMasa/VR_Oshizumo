using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class SceneReset : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Input_Sources RHandType;

    [SerializeField]
    private SteamVR_Action_Boolean RHandAction;

    [SerializeField]
    private SteamVR_Input_Sources LHandType;

    [SerializeField]
    private SteamVR_Action_Boolean LHandAction;


    int count = 0;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || RHandAction.GetState(RHandType) || LHandAction.GetState(LHandType))
        {
            count++;
        }
        else
        {
            count = 0;
        }

        if (count > 60)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}