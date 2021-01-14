using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitch : MonoBehaviour
{

    public List<GameObject> ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// スイッチ
    /// </summary>
    public void ExecuteSwitch() {
        foreach (var item in ui)
        {
            item.SetActive(!item.activeSelf);
        }
    }
}
