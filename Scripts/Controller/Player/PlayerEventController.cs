using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEventController : MonoBehaviour
{
    const string spawner = "Spawner";
    /// <summary>
    /// パーティクル
    /// </summary>
    public List<GameObject> uiList = new List<GameObject>();
    public Transform targetStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray();
    }

    private void OnTriggerStay(Collider other)
    {

    }

    void ItemOpen() { 
    
    }

    void Ray() {
        //Ray ray = new Ray(transform.position, transform.forward);
        //Ray mouseRay = new Ray(this.transform.position, targetStart.transform.forward);
        Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);

        Debug.DrawRay(transform.position, Input.mousePosition, Color.red);
        // 2.		
        // Rayが衝突したコライダーの情報を得る
        RaycastHit hit;
        // Rayが衝突したかどうか
        if (Physics.Raycast(mouseRay, out hit,5))
        {
            if (hit.collider.gameObject.tag == "Untagged" 
                || hit.collider.gameObject.tag == "UTrrrain"
                )
            {
                OffText();
            }
            //スポナーへのアクション
            if (hit.collider.gameObject.tag == CommonController.tagList[(int)CommonController.Tags.spawer])
            {
                var count = (int)CommonController.Tags.spawer;
                if (uiList.Count > count) uiList[count].SetActive(true);
                if (Input.GetKeyDown(KeyCode.V))
                {
                    var com = hit.collider.gameObject.GetComponent<RandomSpawner>();
                    if (com == null) return;
                    com.SpawnerItem();
                    OffText();
                }
            }
            //アイテムのアクション
            if (hit.collider.gameObject.tag == CommonController.tagList[(int)CommonController.Tags.item])
            {
                var count = (int)CommonController.Tags.item;
                if (uiList.Count > count) uiList[count].SetActive(true);
                if (Input.GetKeyDown(KeyCode.V))
                {
                    var com = hit.collider.gameObject.GetComponent<ItemController>();
                    if (com == null) return;
                    uiList[count].GetComponent<Text>().text = com.mItemModel.name;
                    com.GetItemEvent();
                    OffText();
                }
            }
        }
        else {
            OffText();
        }
    }

    private void OffText()
    {
        foreach (var item in uiList)
        {
            item.SetActive(false);
        }
    }

}
