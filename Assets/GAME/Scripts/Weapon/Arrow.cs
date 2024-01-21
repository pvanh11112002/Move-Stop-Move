using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon
{
    private void Update()
    {
        // Điều hướng di chuyển của mũi tên
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, speed * Time.deltaTime);       
    }
    public override void OnInit()
    {
        // Chưa dùng để làm gì cả
        startPos = transform.position;
        newPos = new Vector3(startPos.x, startPos.y, startPos.z + distance);
        
    }
}
