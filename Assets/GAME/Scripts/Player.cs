﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;
public class Player : Character
{
    [SerializeField] SkinnedMeshRenderer meshrRendererToUse;
    public Material[] materialToUse;
    public FloatingJoystick variableJoystick;
    public Transform throwPoint;
    public GameObject throwPointObject;
    public GameObject skin;
    public bool hitEnemy = false;
    public int killCount = 0;
    public GamePlay gamePlay;
    private void Awake()
    {
        gamePlay = GameObject.FindGameObjectWithTag("FromGamePlay").GetComponent<GamePlay>();
    }
    protected override void Start()
    {
        killCount = PlayerPrefs.GetInt("Player Score");
        meshrRendererToUse.material = materialToUse[gamePlay.gamePlaySkinData];
    }
    void Update()
    {
        throwPointObject.transform.rotation = transform.rotation;
        ChooseNextWeapon();        
        Move();
        Shoot(DetectEnemy(transform.position, radius + 2f));
        SaveData();
    }
    private int ChooseNextWeapon()
    {
        // Nhấn để chọn loại vũi khí cho đòn đánh tiếp theo
        // A: Arrow = Mũi tên
        // X: Axe = Rìu
        // B: Boomerang
        if (Input.GetKeyDown(KeyCode.A))
        {
            indexOfWeapon = 0;
            Debug.Log("Arrow");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            indexOfWeapon = 1;
            Debug.Log("Axe");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            indexOfWeapon = 2;
            Debug.Log("Boomerang");
        }
        return indexOfWeapon;
    }
    private void Move()
    {
        //ChangeAnim(runAnim);
        float horizon = variableJoystick.Horizontal;
        float vertical = variableJoystick.Vertical;
        if (Mathf.Abs(horizon) + Mathf.Abs(vertical) < 0.01f)
        {
            ChangeAnim(idleAnim);
            isMoving = false;
            return;
        }
        dir = new Vector3(horizon * speed, 0, vertical * speed);
        transform.forward = dir;
        Vector3 nextPoint = dir * speed * Time.deltaTime + transform.position;
        if (dir != new Vector3(0, 0, 0))
        {
            if (CanMove(nextPoint))
            {
                isMoving = true;               
                transform.position = CheckGround(nextPoint);
                ChangeAnim(runAnim);
                amountBullet = 1;
                hP = 1;
            }
        }
        else
        {
            //ChangeAnim(idleAnim);
            isMoving = false;
        }
    }
    private void UpSize()
    {
        Debug.Log("UpSize");
        transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        transform.position += new Vector3(0, 0.2f, 0);
    }    
    
    private void Shoot(Bot Enemy)
    {
        if (isMoving == false && amountBullet > 0 && Enemy == true)
        {
            transform.LookAt(Enemy.transform);
            ChangeAnim(attackAnim);
            Invoke(nameof(CreateBulletForPlayer), 0.75f);
            //bullet.OnInit();


            amountBullet = 0;
            if (hitEnemy == true)
            {
                //Debug.Log("Hit Enemy");                              
                Invoke("UpSize", 1f);
                hitEnemy = false;
            }
            
        }
    }
    private void CreateBulletForPlayer()
    {
        GameObject bullet = ObjectPoolManager.Instance.GetPooledObject(indexOfWeapon);
        if (bullet != null)
        {
            bullet.transform.position = throwPoint.position;
            bullet.transform.forward = transform.forward;
            bullet.SetActive(true);
        }
    }    
    public Bot DetectEnemy(Vector3 center, float radius)
    {
        //Debug.DrawLine(center, new Vector3(center.x + radius, center.y, center.z), Color.blue);
        LayerMask interactiveLayerMask = LayerMask.GetMask(enemyLayer);
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, interactiveLayerMask);
        if (hitColliders.Length > 0)
        {
            return hitColliders[0].GetComponent<Bot>();
        }
        else
        {
            return null;
        }
    }
    private void SaveData()
    {
        PlayerPrefs.SetInt("Player Score", killCount);
    }
    private void GetData()
    {
        Debug.Log(PlayerPrefs.GetInt("Player Score"));
    }
}
