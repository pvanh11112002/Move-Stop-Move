using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed;
    public float distance;
    public Vector3 startPos;
    public float throwSpeed;
    public float rotateSpeed = 500f;
    public Vector3 newPos;

    public virtual void OnInit()
    {
        
    }
    public virtual void OnDespawn()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        { 
            collision.gameObject.SetActive(false);
            OnDespawn();
        }
        else
        {
            Invoke("OnDespawn()", 2.5f);
        }
    }    
}
