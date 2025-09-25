using UnityEngine;

public interface IState
{

    public void Initialize();
    public void Enter();
    public void Update();
    public void Exit();

};