using PakuPakuOnLine.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // Start is called before the first frame update
    #region プロパティ
    [SerializeField]
    public long id = 0;
    public MItemModel mItemModel;
    public Rigidbody rigidbody;
    public bool isMove = false;
    public bool isUsed = false;
    public float moveSpeed = 1;
    public float maxSpeed = 2;
    #endregion
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        SetStatus();
        StartAction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //プレイヤーが近い
        if (other.tag == CommonController.tagList[(int)CommonController.Tags.player]) { 
            this.transform.LookAt(other.transform);
            if (isMove)
            {
                if (rigidbody.velocity.z < maxSpeed) 
                {
                    rigidbody.velocity += transform.forward * moveSpeed;
                }
            }
        }
    }

    public void SetStatus() {
        //共通部品から取得
        mItemModel = CommonController.itemModels.Where(x => x.id == this.id).ToList().First();
    }

    /// <summary>
    /// アイテム入手
    /// </summary>
    public void GetItemEvent() {
        //TODO:アイテム入手
        if (isUsed) return;
        isUsed = true;
        Destroy(this.gameObject);
    }

    public void StartAction() {
        this.rigidbody.AddForce(this.gameObject.transform.up * 200f+ this.gameObject.transform.right * Random.Range(-100,100));
    }
}
