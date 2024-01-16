using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//State Machine cho Bot, bao gồm 3 state là OnEnter, OnExcute, OnExit
public interface IState<T>
{
    void OnEnter(T t);
    void OnExcute(T t);
    void OnExit(T t);

}
