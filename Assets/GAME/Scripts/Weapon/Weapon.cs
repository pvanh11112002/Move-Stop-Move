using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Rcm dùng transform.position
    //public Rigidbody rb;
    public float speed;
    public float distance;
    public Vector3 startPos;
    public float throwSpeed;
    public float rotateSpeed = 500f;
    public void OnDespawn()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.enabled = false;
            OnDespawn();
        }
    }    
}
