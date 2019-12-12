using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning_or_Losing : MonoBehaviour
{
    // エネミーオブジェクト取得
    public GameObject TargetObject;

    // 勝ち負けのテキストオブジェクト取得
    public GameObject Win;
    public GameObject Lose;

    bool IsJutge = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsJutge) return;

        // プレイヤー勝ち判定
        if (TargetObject.transform.position.y <= -50)
        {
            // オブジェクトをアクティブにする
            Win.SetActive(true);
            IsJutge = true;
        }

        // プレイヤー負け判定
        if (this.transform.position.y <= -50)
        {
            // オブジェクトをアクティブにする
            Lose.SetActive(true);
            IsJutge = true;
        }
    }
}
