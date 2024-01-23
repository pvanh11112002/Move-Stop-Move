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
    public float radius = 15f;
    [HideInInspector] public string enemyLayer = "Enemy";
    [HideInInspector] public string playerLayer = "Player";
    [HideInInspector] public bool isMoving = false;
    [HideInInspector] public bool hasEnemy = false;
    public int hP = 1;
    public Weapon[] weaponPrefabs;
    public int indexOfWeapon = 0; 
    public Animator anim;
    public static string idleAnim = "idle";
    public static string runAnim = "run";
    public static string attackAnim = "attack";
    private string currentAnim;


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
    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(animName);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }
}
