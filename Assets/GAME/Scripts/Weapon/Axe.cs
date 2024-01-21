using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{    
    void Start()
    {
        OnInit();
    }
    private void Update()
    {
        // Điều hướng di chuyển 
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, speed * Time.deltaTime);
        //Invoke("OnDespawn()", 2.5f);

    }
    public override void OnInit()
    {
        //Cái này cũng chưa chạy
        newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);
        startPos = transform.position;       
    }
}
