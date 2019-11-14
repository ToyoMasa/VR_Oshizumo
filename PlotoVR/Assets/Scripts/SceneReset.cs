using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class SceneReset : MonoBehaviour
{
    [SerializeField]
    private SteamVR_Input_Sources hand_type_;

    [SerializeField]
    private SteamVR_Action_Boolean hand_action_;

    int count = 0;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || hand_action_.GetState(hand_type_))
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