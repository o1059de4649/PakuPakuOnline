using UltimateTerrains;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public UltimateTerrain ultimateTerrain;
    public Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameStart() {
        var obj = Instantiate(player, initPos, Quaternion.identity);
        ultimateTerrain.PlayerTransform = obj.transform;
        ultimateTerrain.enabled = true;
    }
}
