using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotatingControl : Weapon
{
    void Update()
    {
        transform.Rotate(new Vector3(0,-(rotateSpeed * Time.deltaTime), 0), Space.Self);
    }
}
