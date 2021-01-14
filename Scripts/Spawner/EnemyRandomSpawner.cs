using PakuPakuOnLine.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawner : MonoBehaviour
{
    private bool isSpawned = false;
    public bool atStart = false;
    public bool isOnce = true;
    private bool isDestory = false;
    public int minEnemyCount = 1;
    public int maxEnemyCount = 2;
    public float positionRange = 5.0f;
    public float height = 5.0f;
    public GameObject enemy;
    public List<int> idList;
    public List<GameObject> childrenObj = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawner born");
        //スポーン済み
        if (isSpawned) return;
        if (atStart) SpawnerItem();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// アイテム生成
    /// </summary>
    public void SpawnerItem()
    {
        isSpawned = true;
        if (isDestory) return;
        //スポーン処理
        foreach (var item in idList)
        {
            var randomCount = Random.Range(minEnemyCount, maxEnemyCount + 1);
            for (int i = 0; i < randomCount; i++)
            {
                var x = this.transform.position.x + Random.Range(-positionRange, positionRange);
                var y = this.transform.position.y + height;
                var z = this.transform.position.z + Random.Range(-positionRange, positionRange);
                var randomPos = new Vector3(x, y, z);
                //IDを渡す
                enemy.GetComponent<EnemyPropertySetController>().id = item;
                //敵生成
                var obj = Instantiate(enemy, randomPos, Quaternion.identity);
                childrenObj.Add(obj);
            }
        }
        isDestory = true;
        if (isOnce) Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        foreach (var item in childrenObj)
        {
            Destroy(item);
        }
    }
}
