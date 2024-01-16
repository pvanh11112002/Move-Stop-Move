using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//State tấn công
public class AttackState : IState<Bot>
{
    public void OnEnter(Bot t)
    {
        ////Transform tagert = GameObject.Find("Finish Place").transform;
        //t.SetDestination(LevelManager.Instance.FinishPoint);
    }

    public void OnExcute(Bot t)
    {
        //if (t.BrickCount == 0)//Nếu hết gạch thì đổi sang state di chuyển tìm gạch
        //{
        //    t.ChangeState(new PatrolState());
        //}
    }

    public void OnExit(Bot t)
    {

    }
}
