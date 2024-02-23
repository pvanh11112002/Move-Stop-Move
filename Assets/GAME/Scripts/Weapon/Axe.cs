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
        // Điều hướng di chuyển  rìu
        startPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().transform.position;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, speed * Time.deltaTime);
        DestroyOutRange(startPos, transform.position);
    }
    public override void OnInit()
    {        
              
    }
}
