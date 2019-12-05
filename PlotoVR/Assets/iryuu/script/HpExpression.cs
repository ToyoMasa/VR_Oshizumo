using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpExpression : MonoBehaviour
{
    
    public Material MyMaterial_;//自分のマテリアル
    private Color DefaultColor_=new Color(1.0f,0.6f,0.0f);
    [Range(0.0f,1.0f)]public float ColorChangeSpeed_;//色変更速度

    private void Start()
    {
         MyMaterial_.color = DefaultColor_;
    }
    //当たった処理
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "HumanEnemy")//おっさんの場合
        {
            MyMaterial_.color = new Color(MyMaterial_.color.r, MyMaterial_.color.g - ColorChangeSpeed_, MyMaterial_.color.b);
            if (MyMaterial_.color.g < 0.0f) MyMaterial_.color= new Color(MyMaterial_.color.r, 0.0f, MyMaterial_.color.b);
        }
    }

}
