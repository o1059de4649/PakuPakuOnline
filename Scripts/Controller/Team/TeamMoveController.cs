using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamMoveController : MonoBehaviour
{
    public bool isGravity = true;
    public CharacterController characterController;
    public float walkSpeed;
    public float cycleMaxTime;
    public float cycleMinTime;
    private float _cycleTime;
    private bool _isStop = false;
    public EnemyPropertySetController controller;
    public Transform chaseTarget;
    public Transform parent_spawner;
    public Status status = Status.None;
    public enum Status
    {
        None,
        Chase,
        Dead
    }
    // Start is called before the first frame update
    void Start()
    {
        parent_spawner = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyByDistance();
        GravityMove();
        ChangeStatus();

        //ステータスによって行動を変える
        switch (status)
        {
            case Status.None:
                Move();
                break;
            case Status.Chase:
                Chase();
                break;
        }

    }

    /// <summary>
    /// ステータス変更
    /// </summary>
    void ChangeStatus()
    {
        //ターゲットがいる
        if (chaseTarget != null)
        {
            status = Status.Chase;
        }
        else
        {
            status = Status.None;
        }
    }

    /// <summary>
    /// 重力メソッド
    /// </summary>
    void GravityMove()
    {
        if (isGravity)
        {
            characterController.Move(transform.up * -0.5f);
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        //ストップフラグ
        if (_isStop) return;

        //サイクルを回す
        _cycleTime += Time.deltaTime;
        if (_cycleTime > Random.Range(cycleMinTime, cycleMaxTime))
        {
            //方向転換など
            //_isStop = true;
            this.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
            _cycleTime = 0;
        }
        //ランダム歩行
        characterController.Move(transform.forward * walkSpeed / 100.0f);
        controller.animator.SetFloat("SpeedZ", 1);

    }

    /// <summary>
    /// 追う
    /// </summary>
    private void Chase()
    {
        //ストップフラグ
        if (_isStop) return;
        //追いかけて歩行
        this.transform.LookAt(chaseTarget);
        characterController.Move(transform.forward * walkSpeed / 100.0f);
        controller.animator.SetFloat("SpeedZ", 1);
    }

    private void DestroyByDistance()
    {

    }

}
