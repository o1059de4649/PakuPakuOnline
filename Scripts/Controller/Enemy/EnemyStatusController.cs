using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PakuPakuOnLine.Model;

public class EnemyStatusController : MonoBehaviour
{
    //敵キャラクターID
    public long id;
    public EnemyPropertySetController controller;
    public float maxHp;
    public float hp;
    public float maxMp;
    public float mp;
    public float exp;
    public GameObject worldUI;
    private Slider slider;
    private Camera playerCamera;
    // Start is called before the first frame update

    private float plus_level = 1;

    void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) Dead();
        UISliderUpadte();
    }

    void Dead() {
        //DeadのAnimation
        controller.enemyMoveController.enabled = false;
        Destroy(this.gameObject);
    }

    /// <summary>
    /// セットアップ
    /// </summary>
    void SetUp() {
        //原点からの距離
        plus_level = 1 + Vector3.Distance(this.transform.position, new Vector3(0,0,0)) / 100;

        maxHp *= plus_level;
        maxMp *= plus_level;
        hp = maxHp * plus_level;
        mp = maxMp * plus_level;
        exp *= plus_level;

        worldUI.transform.localPosition = new Vector3(0, controller.characterController.height, 0);
        slider = GetComponentInChildren<Slider>();
        playerCamera = Camera.main;
    }

    /// <summary>
    /// バー調整
    /// </summary>
    void UISliderUpadte() {
        worldUI.transform.LookAt(playerCamera.transform);
        slider.value = (hp/maxHp);
    }

}
