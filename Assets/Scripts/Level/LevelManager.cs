using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager 
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

    private LevelManager() { }
    #endregion

    public int level = 1;

    public void IncreaseLevel()
    {
        level++;
        GoToNextLevel(); 
    }

    public void startLevelEntry()
    {
        level = 1;
        UIManager.Instance.ResetLifes();
        UIManager.Instance.ResetScore();
        EnemyManager.Instance.ClearAllAsteroids();
        BulletManager.Instance.ClearAllBullets();
        BulletManager.Instance.DestroyAllBullets();
        EnemyManager.Instance.PreInitialize();
        ShipManager.Instance.PreInitialize();
        BulletManager.Instance.PreInitialize();
    }

    public void ResetSameLevel()
    {
        Debug.Log("Reset Level");
        EnemyManager.Instance.ClearAllAsteroids();
        BulletManager.Instance.ClearAllBullets();
        EnemyManager.Instance.PreInitialize();
        ShipManager.Instance.SpawnShip();
    } 

    public void GoToNextLevel()
    {
        Debug.Log("You win, go to next level");
        UIManager.Instance.ResetLifes();
        EnemyManager.Instance.PreInitialize();
        ShipManager.Instance.PreInitialize();
        BulletManager.Instance.ClearAllBullets();
        BulletManager.Instance.DestroyAllBullets();
        BulletManager.Instance.PreInitialize();
    }

}
