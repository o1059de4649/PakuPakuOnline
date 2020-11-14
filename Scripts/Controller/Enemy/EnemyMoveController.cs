using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    public bool isGravity = true;
    public CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GravityMove();
    }

    /// <summary>
    /// 重力メソッド
    /// </summary>
    void GravityMove() {
        if (isGravity) 
        {
            characterController.Move(transform.up * -0.5f);
        }
    }

    private void Move()
    {
        this.transform.eulerAngles();
        //ランダム歩行
        characterController.Move(transform.forward * 10);
        
    }
}
