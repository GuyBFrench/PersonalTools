using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    public FloatData speedData;
    
    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles += speedData.value * new Vector3(0, Input.GetAxis("Mouse X"), 0);
            
        }
    }
}
