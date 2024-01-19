using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [HideInInspector] public Vector3 dir;
    public int amountBullet = 0;
    [HideInInspector] public float speed = 2f;
    [HideInInspector] public float radius = 5f;
    [HideInInspector] public string enemyLayer = "Enemy";
    [HideInInspector] public bool isMoving = false;
    [HideInInspector] public bool hasEnemy = false;
    public int hP = 1;

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
