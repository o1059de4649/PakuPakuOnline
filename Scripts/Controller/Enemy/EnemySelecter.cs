using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelecter : MonoBehaviour
{
    public string BiomeString;
    public List<long> IdList;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 選択されたIDを返す
    /// </summary>
    /// <returns></returns>
    public long ResuldId()
    {
        long resultId = 1;
        //エネミー
        if (CommonController.enemySettingModels.Count > 0) {
            resultId = IdList[Random.Range(0,IdList.Count)];
        }
        return resultId;
    }
}
