using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//State tấn công
public class AttackState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        //t.ChangeAnim(Character.attackAnim);
        //t.ShootPlayer(t.DetectPlayer(t.transform.position, t.radius));
        //t.amountBullet = 0;
        t.ShootPlayer(t.DetectPlayer(t.transform.position, t.radius));
        t.amountBullet = 0;
    }

    public void OnExcute(Bot t)
    {      
        t.ChangeState(new PatrolState());       
    }

    public void OnExit(Bot t)
    {
          
    }
    
}
