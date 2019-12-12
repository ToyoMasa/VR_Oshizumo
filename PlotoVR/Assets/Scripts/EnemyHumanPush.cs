using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHumanPush : MonoBehaviour
{
    public Transform Target;
    public float PushPower = 20;
    public float BackPower = 20;
    public float JumpPower = 10;
    public float WaitToPushTime = 2.0f;
    public float PushToBackTime = 0.2f;
    public float BackToWaitTime = 0.2f;

    public delegate void Action();
    Action EnemyAction;
    Rigidbody Rigid;
    Animator Anim;
    float Timer;

    // ヒット時イベント
    // <！> :このイベントが無いとエラー発生
    public void Hit()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
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
        Anim.SetBool("IsRun", false);

        if (Target.position.y <= 0) return;

        Vector3 front = Target.position - transform.position;
        front.y = 0;
        front = front.normalized;

        // ターゲットに向く
        Quaternion targetRotation = Quaternion.LookRotation(front);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

        if (Timer > WaitToPushTime) ActionChange(Push);
    }

    void Push()
    {
        Anim.SetBool("IsRun", true);

        //Rigid.AddForce(transform.up * JumpPower);
        //Rigid.AddForce(transform.forward * PushPower);

        if (Timer > PushToBackTime) ActionChange(Back);

    }
    void Back()
    {
        Anim.SetBool("IsRun", false);

        //Rigid.AddForce(-transform.forward * BackPower);

        if (Timer > BackToWaitTime) ActionChange(Wait);
    }
}
