using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//State di chuyển
public class PatrolState : IState<Bot>
{
    public bool IsDestinnation;

    public void OnEnter(Bot t)
    {
        //t.amountBullet = 1;
        t.ChangeAnim(Character.runAnim);
        t.agent.SetDestination(t.destination);
    }

    public void OnExcute(Bot t)
    {
        //Debug.Log("Đã gọi đến OnExcute");
        if (IsDestinnation == true)
        {
            t.destination = t.Destination();
            t.agent.SetDestination(t.destination);
        }
        IsDestinnation = Vector3.Distance(t.transform.position, t.destination) < 1f;
        if(t.DetectPlayer(t.transform.position, t.radius) == true)
        {
            t.ChangeState(new AttackState());
        }    
    }

    public void OnExit(Bot t)
    {

    }
    
}
