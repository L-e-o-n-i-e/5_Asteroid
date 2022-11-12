using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFlow : IPreInitialize, IInitialize, IRefresh, IPhysicsRefresh, IEndGame
{
    
}
public interface IPreInitialize
{
     void PreInitialize();
}
public interface IInitialize
{
    void Initialize();
}
public interface IRefresh
{
    void Refresh();
}
public interface IPhysicsRefresh
{
    void PhysicsRefresh();
}

public interface IEndGame
{
    void EndGame();
}