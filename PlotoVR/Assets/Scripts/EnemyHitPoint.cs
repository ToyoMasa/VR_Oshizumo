using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPoint : MonoBehaviour
{
    public int HP = 10;
    public float DamageBackPower = 10.0f;
    public GameObject HitParticle;

    float Timer = 0.0f;
    bool IsHit = false;

    Rigidbody Rigid;

    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(IsHit) Timer += Time.deltaTime;

        if (Timer > 0.1f) IsHit = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        bool IsHitController = other.gameObject.tag == "GameController";

        if (HitParticle && IsHitController && !IsHit)
        {
            IsHit = true;
            Timer = 0.0f;

            HP--;

            Vector3 hitPos = other.ClosestPoint(other.transform.position);

            Instantiate(HitParticle, hitPos, other.transform.rotation);
        }

        if (HP <= 0)
        {
            Rigid.AddForce(transform.up);
            Rigid.AddForce(-transform.forward * DamageBackPower);
        }
    }
}
