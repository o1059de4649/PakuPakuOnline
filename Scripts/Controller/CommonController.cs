using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonController : MonoBehaviour
{
    /// <summary>
    /// タグリスト
    /// </summary>
    public static readonly List<string> tagList = new List<string>() {"Player","Spawner", "Item" };
    /// <summary>
    /// タグ一覧
    /// </summary>
    public enum Tags {
        player,
        spawer,
        item,
    };
    public static readonly string SpeedX = "SpeedX";
    public static readonly string SpeedZ = "SpeedZ";

    /// <summary>
    /// 全てのアイテム
    /// </summary>
    public static readonly List<ItemModel> itemModels = SetAllSettings();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// DBから取得
    /// </summary>
    static private List<ItemModel> SetAllSettings() {
        var result = new List<ItemModel>();
        return result;
    }
}
