using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed;
    public float throwSpeed;
    public float distance = 5f;   
    [SerializeField] public float rotateSpeed = 500f;
    [SerializeField] public Vector3 startPos;
    [SerializeField] public Vector3 newPos;
    

    public virtual void OnInit()
    {
       
    }
    public virtual void OnDespawn()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameObject.Find("Player").GetComponent<Player>().hitEnemy = true;
            GameObject.Find("Player").GetComponent<Player>().killCount++;
            //player.hitEnemy = true;
            collision.gameObject.SetActive(false);
            OnDespawn();
        }
        else if(collision.CompareTag("Player"))
        {
            Debug.Log("hit");
            collision.gameObject.SetActive(false);
            OnDespawn();
        }    
        
    }    
    public void DestroyOutRange(Vector3 a, Vector3 b)
    {
        if (Vector3.Distance(a, b) >= distance)
        {
            //Debug.Log("Destroy Out Range");
            //Debug.Log(Vector3.Distance(a, b));
            OnDespawn();
        }    
    }    
}
