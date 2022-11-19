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
    bool newGame = true;

    public int IncreaseLevel()
    {
        return level++;
    }

    public void startLevelEntry()
    {
        level = 1;

        UIManager.Instance.ResetLifes();
        UIManager.Instance.ResetScore();
        EnemyManager.Instance.ClearAllAsteroids();
        EnemyManager.Instance.PreInitialize();
        ShipManager.Instance.PreInitialize();
        BulletManager.Instance.PreInitialize();
    }

    public void ResetSameLevel()
    {
        Debug.Log("Reset Level");
        EnemyManager.Instance.ClearAllAsteroids();
        EnemyManager.Instance.PreInitialize();
        ShipManager.Instance.SpawnShip();
    }

    public void GoToNextLevel()
    {
        Debug.Log("You win, go to next level");
        UIManager.Instance.ResetLifes();
        EnemyManager.Instance.SpawnAsteroid(Asteroids.Level.Biggest, new Vector2(0, 0));
        ShipManager.Instance.PreInitialize();
        BulletManager.Instance.ClearAllBUllets();
        BulletManager.Instance.PreInitialize();
    }

}
