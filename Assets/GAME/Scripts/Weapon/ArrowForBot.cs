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
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, speed * Time.deltaTime);
        Invoke(nameof(OnDespawn), 5f);
    }
    public override void OnInit()
    {
        firsPoint = this.transform.position; 

    }
}
