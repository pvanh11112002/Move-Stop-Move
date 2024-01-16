using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    public Vector3 dir;
    [HideInInspector] public int amountBullet = 0;
    public float speed = 2f;   
    public float radius = 5f;
    public string enemyLayer = "Enemy";
    public bool isMoving = false;
    public bool hasEnemy = false;

    protected virtual void Start()
    {
        
    }
    void Update()
    {
        
    }
    public virtual void OnInit()
    {

    }    
    public Vector3 CheckGround(Vector3 nextPoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 2f, groundLayer))
        {
            return hit.point + Vector3.up * 1.1f;
        }
        return transform.position;
    }
    public bool CanMove(Vector3 nextPoint)
    {
        bool isCanMove = false;
        RaycastHit hit;
        if (Physics.Raycast(nextPoint, Vector3.down, out hit, 2f, groundLayer))
        {
            isCanMove = true;
        }
        return isCanMove;
    }
    
}
