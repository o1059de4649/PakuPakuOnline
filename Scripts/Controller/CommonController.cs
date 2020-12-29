using PakuPakuOnLine.Model;
using PakuPakuOnLine.Repository;
using System;
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
    public static readonly string connectionString = "http://133.167.68.6/PakuPakuDB/testGet.php";

    /// <summary>
    /// 全てのアイテム
    /// </summary>
    public static readonly List<MItemModel> itemModels = SetAllSettings();

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
    static private List<MItemModel> SetAllSettings() {

        try
        {
            //DBから取得する処理
            var repo = new MItemRepository();
            var result = repo.GetMItemAll(connectionString);
            return result;
        }
        catch (Exception)
        {
            Cursor.visible = true;
            throw;
        }

    }
}
