using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//State di chuyển
public class PatrolState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        
        Debug.Log(t.amountBullet);
        //t.ChangeAnim(Character.runAnim);
        //t.agent.SetDestination(t.destination);
    }

    public void OnExcute(Bot t)
    {
        if (t.IsDestinnation)
        {
            t.destination = t.Destination();
            t.agent.SetDestination(t.destination);
        }
        if (t.DetectPlayer(t.transform.position, t.radius))
        {
            t.amountBullet = 1;
            t.ChangeState(new AttackState());
        }
        //else if(!t.DetectPlayer(t.transform.position, t.radius))
        //{
        //    t.ChangeState(new PatrolState());
        //}
    }

    public void OnExit(Bot t)
    {
        
    }
    
}
