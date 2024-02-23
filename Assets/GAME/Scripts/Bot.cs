using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public class Bot : Character
{
    public NavMeshAgent agent;                                          
    IState<Bot> currentState;
    public Vector3 destination;
    public bool IsDestinnation => Vector3.Distance(destination, Vector3.right * transform.position.x + Vector3.forward * transform.position.z) < 1f;
    public Transform throwPointOfBot;
    private bool hasPlayerInVis;
    public int tagNum;

    public override void OnInit()
    {
        base.OnInit();
        agent = GetComponent<NavMeshAgent>();
    }
    protected override void Start()
    {
        base.Start();
        ChangeState(new PatrolState());
    }
    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExcute(this);
        }
    }
    //Set điểm đến theo NavMesh
    public Vector3 Destination()
    {
       
        this.destination = new Vector3(UnityEngine.Random.Range(-LevelManager.Instance.rangeX, LevelManager.Instance.rangeX), 0, UnityEngine.Random.Range(-LevelManager.Instance.rangeZ, LevelManager.Instance.rangeZ));
        return destination;
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
        LayerMask botInteractiveLayerMask = LayerMask.GetMask(playerLayer);
        Collider[] hitPlayerColliders = Physics.OverlapSphere(center, radius, botInteractiveLayerMask);
        if (hitPlayerColliders.Length > 0)
        {
            hasPlayerInVis = true;
            return hitPlayerColliders[0].GetComponent<Player>();
        }
        else
        {
            hasPlayerInVis = false;
            return null;
        }
    }
    public void ShootPlayer(Player player)
    {
        if (amountBullet > 0 && hasPlayerInVis)
        {
            transform.LookAt(player.transform);
            CreateBullet();
        }

    }
    private void CreateBullet()
    {
        //int indexBulletOfOwn = 0;
        ////Debug.Log("bắt đầu tạo đạn");
        //for (int i = 0; i < ObjectPoolManager.instance.numberOfBot; i++)
        //{
        //    if (ObjectPoolManager.instance.GetPooledObjectOfBot(i) == null)
        //    {
        //        indexBulletOfOwn++;
        //        if(indexBulletOfOwn == ObjectPoolManager.instance.numberOfBot)
        //        {
        //            indexBulletOfOwn = 0;
        //        }    
        //    }    
        //}
        GameObject bulletOfBot = ObjectPoolManager.Instance.GetPooledObjectOfBot(tagNum);
        if (bulletOfBot != null)
        {
            //Debug.Log("Bullet khác null");
            bulletOfBot.transform.position = throwPointOfBot.position;
            bulletOfBot.transform.forward = transform.forward;
            bulletOfBot.SetActive(true);
            //Debug.Log("Tạo đạn rồi set active");
        }
    }    
}
