using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPoint : MonoBehaviour
{
    public int HP = 10;
    public float DamageBackPower = 10.0f;
    public GameObject HitParticle;

    float timer = 0.0f;
    bool IsHit = false;

    Rigidbody Rigid;

    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(IsHit) timer += Time.deltaTime;

        if (timer > 0.1f) IsHit = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        bool IsHitController = other.gameObject.tag == "GameController";

        if (HitParticle && IsHitController && !IsHit)
        {
            IsHit = true;
            timer = 0.0f;

            Debug.Log("Hit" + other.gameObject.tag);

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
