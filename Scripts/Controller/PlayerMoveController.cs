using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public CharacterController characterController;
    public float moveSpeed = 10.0f;

    [SerializeField]
    private Transform character;    //キャラクターをInspectorウィンドウから選択してください
    [SerializeField]
    private Transform pivot;    //キャラクターの中心にある空のオブジェクトを選択してください
                                //カメラ上下移動の最大、最小角度です。Inspectorウィンドウから設定してください
    [Range(-0.999f, -0.5f)]
    public float maxYAngle = -0.5f;
    [Range(0.5f, 0.999f)]
    public float minYAngle = 0.5f;
    public float gravity = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        RotateControl();
    }

    /// <summary>
    /// ムーブメント
    /// </summary>
    void Movement() {
        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move(this.transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(this.transform.right * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(this.transform.forward * -moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(this.transform.right * -moveSpeed);
        }
        if (Input.GetKeyUp(KeyCode.A)
            || Input.GetKeyUp(KeyCode.S)
            || Input.GetKeyUp(KeyCode.W)
            || Input.GetKeyUp(KeyCode.D)
            ) {
            characterController.Move(Vector3.zero);
        }
        //重力
        if (!characterController.isGrounded)
        {
            characterController.Move(this.transform.up * -gravity);
        }
    }

    void RotateControl() {
        //マウスのX,Y軸がどれほど移動したかを取得します
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");
        //Y軸を更新します（キャラクターを回転）取得したX軸の変更をキャラクターのY軸に反映します
        character.transform.Rotate(0, X_Rotation, 0);
        pivot.transform.Rotate(-Y_Rotation, 0, 0);

        //次はY軸の設定です。
        float nowAngle = pivot.transform.localRotation.x;
        //最大値、または最小値を超えた場合、カメラをそれ以上動かない用にしています。
        //キャラクターの中身が見えたり、カメラが一回転しないようにするのを防ぎます。
        if (-Y_Rotation != 0)
        {
            if (0 < Y_Rotation)
            {
                if (minYAngle <= nowAngle)
                {
                    pivot.transform.Rotate(-Y_Rotation, 0, 0);
                }
            }
            else
            {
                if (nowAngle <= maxYAngle)
                {
                    pivot.transform.Rotate(-Y_Rotation, 0, 0);
                }
            }
        }
    }
}
