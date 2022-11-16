using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : IFlow
{
    #region Singleton
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = new UIManager();

            return instance;
        }

    }
    private UIManager() { }
    #endregion

    private int startingShipHp = 3;


    public void PreInitialize()
    {
        Debug.Log("PreInitialize UIManager");
    }

    public void Initialize()
    {
    }

    public void Refresh()
    {
    }

    public void PhysicsRefresh()
    {
    }

    public void EndGame()
    {
    }


}
