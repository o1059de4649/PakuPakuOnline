using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public CharacterController characterController;
    public float moveSpeed = 10.0f;

    [SerializeField]
    private Transform x_pivot;    //キャラクターをInspectorウィンドウから選択してください
    [SerializeField]
    private Transform y_pivot;    //キャラクターの中心にある空のオブジェクトを選択してください
                                //カメラ上下移動の最大、最小角度です。Inspectorウィンドウから設定してください
    [Range(-0.999f, -0.5f)]
    public float maxYAngle = -0.5f;
    [Range(0.5f, 0.999f)]
    public float minYAngle = 0.5f;
    public float gravity = 0.5f;
    public Animator anim;
    /// <summary>
    /// アニメーション閾値最大値
    /// </summary>
    private readonly float max_anime = 1;
    /// <summary>
    /// アニメーション閾値乗算
    /// </summary>
    private readonly float multi_anime = 3;
    /// <summary>
    /// アニメーション専用移動X値
    /// </summary>
    public float move_x {
        get { return _move_x; }
        set {
            _move_x = value;
            if (value > max_anime) _move_x = max_anime;
            if (value < -max_anime) _move_x = -max_anime;
        }
    }
    private float _move_x = 0;
    /// <summary>
    /// アニメーション専用移動Z値
    /// </summary>
    public float move_z
    {
        get { return _move_z; }
        set
        {
            _move_z = value;
            if (value > max_anime) _move_z = max_anime;
            if (value < -max_anime) _move_z = -max_anime;
            
        }
    }
    private float _move_z = 0;

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
        SetAnimation();
        DebugLog();
    }

    /// <summary>
    /// ムーブメント
    /// </summary>
    void Movement() {
        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move(x_pivot.transform.forward * moveSpeed);
            move_z += Time.deltaTime * multi_anime;
            ParentRotateSet();
        }
        if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(x_pivot.transform.right * moveSpeed);
            move_x += Time.deltaTime * multi_anime;
            ParentRotateSet();
        }
        if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(x_pivot.transform.forward * -moveSpeed);
            move_z -= Time.deltaTime * multi_anime;
            ParentRotateSet();
        }
        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(x_pivot.transform.right * -moveSpeed);
            move_x -= Time.deltaTime * multi_anime;
            ParentRotateSet();
        }
        if (Input.GetKeyUp(KeyCode.A)
            || Input.GetKeyUp(KeyCode.S)
            || Input.GetKeyUp(KeyCode.W)
            || Input.GetKeyUp(KeyCode.D)
            ) {
            characterController.Move(Vector3.zero);
            move_x = 0;
            move_z = 0;
        }
        //重力
        if (!characterController.isGrounded)
        {
            characterController.Move(x_pivot.transform.up * -gravity);
        }
    }

    void RotateControl() {
        //マウスのX,Y軸がどれほど移動したかを取得します
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");

        //Y軸を更新します（キャラクターを回転）取得したX軸の変更をキャラクターのY軸に反映します
        x_pivot.transform.Rotate(0, X_Rotation, 0);
        y_pivot.transform.Rotate(-Y_Rotation, 0, 0);

        //次はY軸の設定です。
        float nowAngle = y_pivot.transform.localRotation.x;
        //最大値、または最小値を超えた場合、カメラをそれ以上動かない用にしています。
        //キャラクターの中身が見えたり、カメラが一回転しないようにするのを防ぎます。
        if (-Y_Rotation != 0)
        {
            if (0 < Y_Rotation)
            {
                if (minYAngle <= nowAngle)
                {
                    y_pivot.transform.Rotate(-Y_Rotation, 0, 0);
                }
            }
            else
            {
                if (nowAngle <= maxYAngle)
                {
                    y_pivot.transform.Rotate(-Y_Rotation, 0, 0);
                }
            }
        }
    }

    /// <summary>
    /// アニメ-ションセット
    /// </summary>
    void SetAnimation()
    {
        anim.SetFloat(CommonController.SpeedX, move_x);
        anim.SetFloat(CommonController.SpeedZ, move_z);
    }

    /// <summary>
    /// 動くオブジェクトの角度
    /// </summary>
    void ParentRotateSet() {
        //オブジェクトを回転
        var old_y = x_pivot.transform.eulerAngles.y;
        this.transform.localEulerAngles = new Vector3(0, x_pivot.transform.eulerAngles.y, 0);
        x_pivot.transform.eulerAngles = new Vector3(0, old_y, 0);
    }

    void DebugLog() {
        Debug.Log(move_z);
    }
}
