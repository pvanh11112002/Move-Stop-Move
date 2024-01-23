using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon
{
    private void Start()
    {
        OnInit();
    }
    private void Update()
    {
        // Điều hướng di chuyển của mũi tên
        startPos = GameObject.Find("Player").GetComponent<Player>().transform.position;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, speed * Time.deltaTime);
        DestroyOutRange(startPos, transform.position);
    }
    public override void OnInit()
    {
        
        //newPos = new Vector3(startPos.x, startPos.y, startPos.z + distance);
        
    }
}
