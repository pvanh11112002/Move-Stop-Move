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
    private float rangeX;
    private float rangeZ;
    
    public override void OnInit()
    {
        //base.OnInit();
        //ChangeAnim(idleAnim);       
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
        GameObject planeObject = GameObject.Find("Plane");
        MeshRenderer meshRenderer = planeObject.GetComponent<MeshRenderer>();
        Vector3 size = meshRenderer.bounds.size;
        // Tính range trục x và trục z
        rangeX = size.x * 0.5f; // Đối với plane, kích thước x sẽ là chiều rộng
        rangeZ = size.z * 0.5f; // Đối với plane, kích thước z sẽ là chiều dài
        this.destination = new Vector3(UnityEngine.Random.Range(-rangeX, rangeX), 1, UnityEngine.Random.Range(-rangeZ, rangeZ));
        //agent.enabled = true;
        //agent.SetDestination(destination);
        Debug.Log(destination);
        return destination;
    }

    private void Update()
    {
        if (currentState != null)
        {
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
