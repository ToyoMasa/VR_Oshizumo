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
        if (Target.position.y <= 0) return;

        Vector3 front = Target.position - transform.position;
        front.y = 0;
        front = front.normalized;

        // ターゲットに向く
        Quaternion targetRotation = Quaternion.LookRotation(front);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

        // 一定時間になったらランダムに攻撃
        if (Timer > WaitToPushTime)
        {
            int AnimTarget = Random.Range(0, 3);

            if(AnimTarget == 0) ActionChange(Push);
            if(AnimTarget == 1) ActionChange(RowlingKick);
            if(AnimTarget == 2) ActionChange(Head);
        }
    }

    void Push()
    {
        Anim.SetBool("IsPush", true);

        if (Timer > PushToBackTime) ActionChange(Back);
    }

    void RowlingKick()
    {
        Anim.SetBool("IsRowlingKick", true);

        if (Timer > PushToBackTime) ActionChange(Back);
    }

    void Head()
    {
        Anim.SetBool("IsHead", true);

        if (Timer > PushToBackTime) ActionChange(Back);
    }

    void Back()
    {
        Anim.SetBool("IsPush", false);
        Anim.SetBool("IsRowlingKick", false);
        Anim.SetBool("IsHead", false);

        //Rigid.AddForce(-transform.forward * BackPower);

        if (Timer > BackToWaitTime) ActionChange(Wait);
    }
}
