using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowForBot : Weapon
{
    Vector3 firsPoint;
    private void Start()
    {
        OnInit();
    }
    private void Update()
    {
        //Debug.Log("Ra được mũi tên của bot");      
        // Điều hướng di chuyển của mũi tên
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, speed * Time.deltaTime);
        //transform.localPosition += new Vector3(0, 0, 0.005f);
        Invoke(nameof(OnDespawn), 5f);
        //DestroyOutRange(firsPoint, transform.position);
    }
    public override void OnInit()
    {
        firsPoint = this.transform.position; 
        //newPos = new Vector3(startPos.x, startPos.y, startPos.z + distance);

    }
}
