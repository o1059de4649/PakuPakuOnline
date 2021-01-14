using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPropertySetController : MonoBehaviour
{
    //敵キャラクターID
    public long id;
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public CharacterController characterController;
    [HideInInspector]
    public EnemyMoveController enemyMoveController;
    [HideInInspector]
    public EnemyStatusController enemyStatusController;

    public EnemySelecter enemySelecter;
    // Start is called before the first frame update
    void Awake()
    {
        SetUpAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 設定
    /// </summary>
    void SetUpAll()
    {
        //ID選定
        if (id == 0) id = enemySelecter.ResuldId();
        var targetModels = CommonController.enemySettingModels.Where(x => x.id == id).ToList();
        //もし取得できなかったらオブジェクト破棄
        if (targetModels.Count == 0) Destroy(this.gameObject);
        var targetModel = targetModels.First();
        //初期化
        characterController = GetComponent<CharacterController>();
        enemyMoveController = GetComponent<EnemyMoveController>();
        enemyStatusController = GetComponent<EnemyStatusController>();

        //CharacterController
        characterController.skinWidth = targetModel.mEnemyCharacterControllerModel.skinWidth;
        characterController.slopeLimit = targetModel.mEnemyCharacterControllerModel.slopLimit;
        characterController.stepOffset = targetModel.mEnemyCharacterControllerModel.stepOffset;
        characterController.center = new Vector3(targetModel.mEnemyCharacterControllerModel.center_x
            , targetModel.mEnemyCharacterControllerModel.center_y
            , targetModel.mEnemyCharacterControllerModel.center_z) ;
        characterController.radius = targetModel.mEnemyCharacterControllerModel.radius;
        characterController.height = targetModel.mEnemyCharacterControllerModel.height;
        characterController.minMoveDistance = targetModel.mEnemyCharacterControllerModel.minMoveDistance;
        //MoveController
        enemyMoveController.walkSpeed = targetModel.mEnemyMoveControllerModel.walkSpeed;
        enemyMoveController.isGravity = (targetModel.mEnemyMoveControllerModel.isGravity == "true");
        enemyMoveController.cycleMaxTime = targetModel.mEnemyMoveControllerModel.cycleMaxTime;
        enemyMoveController.cycleMinTime = targetModel.mEnemyMoveControllerModel.cycleMinTime;
        //EnemyStatus
        enemyStatusController.id = targetModel.mEnemyStatusModel.id;
        enemyStatusController.maxHp = targetModel.mEnemyStatusModel.hp;
        enemyStatusController.maxMp = targetModel.mEnemyStatusModel.mp;
        enemyStatusController.exp = targetModel.mEnemyStatusModel.exp;

        //モデル生成
        var prefab = Resources.Load<GameObject>(targetModel.modelPath);
        var obj = Instantiate(prefab, this.transform.position, Quaternion.identity);
        obj.transform.parent = this.transform;
        //アニメイター取得
        var controller = this.GetComponent<EnemyPropertySetController>();
        controller.animator = obj.gameObject.GetComponentInChildren<Animator>();
    }


}
