using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemModel : MonoBehaviour
{
    // Start is called before the first frame update
    #region プロパティ
    [SerializeField]
    public long id = 0;
    public string item_name { get; set; }
    public long item_group_cd { get; set; }
    public long price { get; set; }
    public long value { get; set; }
    public long rarity { get; set; }
    public Rigidbody rigidbody;
    public bool isMove = false;
    public bool isUsed = false;
    public float moveSpeed = 1;
    public float maxSpeed = 2;
    #endregion
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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
        var model = CommonController.itemModels.Where(x => x.id == this.id).ToList().First();
        id = model.id;
        item_name = model.item_name;
        this.name = model.item_name;
        this.item_group_cd = model.item_group_cd;
        this.price = model.price;
        this.rarity = model.rarity;
        this.value = model.value;
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
