using PakuPakuOnLine.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public bool atStart = false;
    public bool isOnce = true;
    private bool isDestory = false;
    public int minItemCount = 1;
    public int maxItemCount = 2;
    public float positionRange = 5.0f;
    public float height = 5.0f;
    public List<GameObject> spawnGameObjects;
    public List<int> idList;
    // Start is called before the first frame update
    void Start()
    {
        if(atStart) SpawnerItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// アイテム生成
    /// </summary>
    public void SpawnerItem() {
        if (isDestory) return;
        //スポーン処理
        foreach (var item in spawnGameObjects)
        {
            var randomCount = Random.Range(minItemCount,maxItemCount+1);
            for (int i = 0; i < randomCount; i++)
            {
                var x = this.transform.position.x + Random.Range(-positionRange, positionRange);
                var y = this.transform.position.y + height;
                var z = this.transform.position.z + Random.Range(-positionRange, positionRange);
                var randomPos = new Vector3(x, y, z);
                var obj = Instantiate(item, randomPos, Quaternion.identity);
                var controller = obj.GetComponent<ItemController>();
                //アイテム決定
                var idNum = Random.Range(0, idList.Count);
                 var resultId = idList[idNum];
                controller.id = resultId;
            }
        }
        isDestory = true;
        if(isOnce) Destroy(this.gameObject);
    }
}
