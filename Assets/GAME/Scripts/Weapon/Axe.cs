using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{    
    private Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }
    private void Update()
    {
        if (transform.position.z >= distance)
        {
            OnDespawn();
        }
        transform.Rotate(new Vector3(0, 0, -(rotateSpeed * Time.deltaTime)), Space.Self);
        transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
            
    }
    public void OnInit()
    {
        newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);
        startPos = transform.position;       
    }
}
