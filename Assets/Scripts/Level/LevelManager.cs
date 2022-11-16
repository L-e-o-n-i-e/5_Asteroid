using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : IFlow
{
    #region Singleton
    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
                instance = new LevelManager();

            return instance;
        }

    }

    #endregion

    public int level = 1;
    private LevelManager() { }

    public void PreInitialize()
    {
        Debug.Log("PreInitialize LevelManager");
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

    public int IncreaseLevel()
    {
       return level++;
    }

    public void startLevelEntry()
    {
        level = 1;
        EnemyManager.Instance.PreInitialize();
        ShipManager.Instance.PreInitialize();
        BulletManager.Instance.PreInitialize();
    }

    public void ResetSameLevel(int Hp)
    {
        //Give HP info to UI
    }
   
}
