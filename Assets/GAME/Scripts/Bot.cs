using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    public NavMeshAgent agent;                                          
    IState<Bot> currentState;
    public Vector3 destination;
    public GameObject[] botWeaponPrefabs;

    public override void OnInit()
    {
        base.OnInit();
        agent = GetComponent<NavMeshAgent>();
        ChangeAnim(idleAnim);
    }
    protected override void Start()
    {
        base.Start();
        ChangeState(new PatrolState());
    }
    //Set điểm đến theo NavMesh
    public Vector3 Destination()
    {
       
        this.destination = new Vector3(UnityEngine.Random.Range(-LevelManager.Instance.rangeX, LevelManager.Instance.rangeX), 1, UnityEngine.Random.Range(-LevelManager.Instance.rangeZ, LevelManager.Instance.rangeZ));
        //agent.enabled = true;
        //agent.SetDestination(destination);
        return destination;
    }

    private void Update()
    {
        if (currentState != null)
        {
            //if(hP <= 0)
            //{
            //    Destroy(gameObject);
            //}    
            currentState.OnExcute(this);
        }
    }

    public void ChangeState(IState<Bot> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = state;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    internal void MoveStop()
    {
        agent.enabled = false;
    }
    public Player DetectPlayer(Vector3 center, float radius)
    {
        Debug.DrawLine(center, new Vector3(center.x + radius, center.y, center.z), Color.blue);
        LayerMask interactiveLayerMask = LayerMask.GetMask(playerLayer);
        Collider[] hitPlayerColliders = Physics.OverlapSphere(center, radius, interactiveLayerMask);
        if (hitPlayerColliders.Length > 0)
        {
            return hitPlayerColliders[0].GetComponent<Player>();
        }
        else
        {
            return null;
        }
    }
    public void ShootPlayer(Player player)
    {
        //if (t.isMoving == false && t.amountBullet > 0 && Enemy == true)
        //{
        //    transform.LookAt(Enemy.transform);
        //    ChangeAnim(attackAnim);
        //    Invoke(nameof(CreateBullet), 0.75f);
        //    //bullet.OnInit();


        //    amountBullet = 0;
        //    if (hitEnemy == true)
        //    {
        //        Debug.Log("Hit Enemy");
        //        Invoke("UpSize", 1f);
        //        hitEnemy = false;
        //    }

        //}
        if(amountBullet > 0)
        {
            Invoke(nameof(CreateBullet), 0.75f);
            amountBullet = 0;
        }

    }
    public void CreateBullet(Bot t)
    {
        GameObject bulletOfBot = ObjectPoolManager.instance.GetPooledObject(0);
        if (bulletOfBot != null)
        {
            bulletOfBot.transform.position = t.transform.position;
            bulletOfBot.transform.forward = t.transform.forward;
            bulletOfBot.SetActive(true);
        }
    }
}
