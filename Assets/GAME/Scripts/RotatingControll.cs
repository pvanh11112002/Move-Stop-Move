using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingControll : Weapon
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -(rotateSpeed * Time.deltaTime)), Space.Self);
    }
}
