using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotController : MonoBehaviour
{
    public Transform targetTransForm;
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = targetTransForm.position;
    }
}
