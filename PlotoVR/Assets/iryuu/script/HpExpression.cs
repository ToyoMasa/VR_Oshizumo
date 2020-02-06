using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpExpression : MonoBehaviour
{
    public float DamageUpPower = 10.0f;
    public float DamageBackPower = 10.0f;

    public Material MyMaterial_;
    [Range(0.0f, 1.0f)] public float ColorChangeSpeed_;

    public GameObject DamageSound;

    private Color DefaultColor_ = new Color(1.0f, 0.6f, 0.0f);

    float Timer = 0.0f;
    bool IsHit = false;
    bool IsHandHit = false;

    Rigidbody Rigid;

    private void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        MyMaterial_.color = DefaultColor_;
    }

    private void Update()
    {
        if (IsHit) Timer += Time.deltaTime;
        if (Timer > 0.5f) IsHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        IsHandHit = true;
        IsHit = true;
        Timer = 0.0f;
    }

    private void OnTriggerExit(Collider other)
    {
        IsHandHit = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsHandHit) return;

        if (collision.gameObject.name == "HumanEnemy" && !IsHit)
        {
            IsHit = true;
            Timer = 0.0f;

            Instantiate(DamageSound, collision.transform);

            MyMaterial_.color = new Color(MyMaterial_.color.r, MyMaterial_.color.g - ColorChangeSpeed_, MyMaterial_.color.b);
            if (MyMaterial_.color.g < 0.0f) MyMaterial_.color = new Color(MyMaterial_.color.r, 0.0f, MyMaterial_.color.b);
        }

        if (MyMaterial_.color.g <= 0.0f && IsHit)
        {
            Rigid.AddForce(transform.up * DamageUpPower);
            Rigid.AddForce(-transform.forward * DamageBackPower);
        }
    }

}
