using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPush : MonoBehaviour
{
    public Transform Target;
    public float PushPower = 20;
    public float BackPower = 20;
    public float JumpPower = 10;

    public delegate void Action();
	Action EnemyAction;
    float Timer;
    Rigidbody Rigid;

    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        EnemyAction = Wait;
        Timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        EnemyAction();
    }
    void ActionChange(Action ChangeAction)
    {
        Timer = 0.0f;
        EnemyAction = ChangeAction;
    }

    void Wait()
    {
        if (Target.position.y <= 0) return;

        Vector3 front = Target.position - transform.position;
        front.y = 0;
        front = front.normalized;

        // ターゲットに向く
        Quaternion targetRotation = Quaternion.LookRotation(front);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

        if (Timer > 2.0f) ActionChange(Push);
    }

    void Push()
    {
        if (Timer < 0.2f)
        {
            Rigid.AddForce(transform.forward * PushPower);
            Rigid.AddForce(transform.up * JumpPower);
        }

        if (Timer > 0.2f) ActionChange(Back);

    }
    void Back()
    {
        Rigid.AddForce(-transform.forward * BackPower);
        if (Timer > 0.2f) ActionChange(Wait);
    }
}
