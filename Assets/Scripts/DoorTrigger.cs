using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GemInv _gemInv;
    private bool dororo = false;
    

    private void Awake()
    {
        GemInv _gemInv = GetComponent<GemInv>();
    }

    private void Update()
    {
        if (dororo == true)
        {
            Debug.Log("Here comes the door moving");
            transform.position = new Vector3(0, Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(_gemInv.GemNum);
        if (_gemInv.GemNum == 0)
        {
            dororo = true;

        }
    }
    
    private void OnCollisionExit(Collision collision)
    {

        dororo = false;

    }
}
