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


    public override void OnInit()
    {
        agent = GetComponent<NavMeshAgent>();
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
}
