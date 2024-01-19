using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon
{
    private Vector3 newPos;
    // Start is called before the first frame update
    private void Start()
    {
        OnInit();
    }
    private void Update()
    {
        if (transform.position.z >= distance)
        {
            OnDespawn();
        }
        transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);

    }
    public void OnInit()
    {
        startPos = transform.position;
        newPos = new Vector3(startPos.x, startPos.y, startPos.z + distance);
        
    }
}
