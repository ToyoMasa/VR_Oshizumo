using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;
//using UnityStandardAssets.ImageEffects;
using UnityEditor;


public class InWater : MonoBehaviour
{

    //　水ゲームオブジェクト
    public Transform water;
    //　水中表現にUIのパネルを使用する場合は設定
    public GameObject waterPanel;
    //　カメラが水と接触しているかどうか
    private bool isInWater = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.y <= water.position.y  )
        {
            waterPanel.SetActive(true);
        }
        isInWater = true;
    }
}
