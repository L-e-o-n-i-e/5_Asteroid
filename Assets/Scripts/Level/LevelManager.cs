using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public AudioClip Win;
    public AudioClip Lose;
    public AudioSource audioSource;

    public void IncreaseLevel()
    {
        level++;
        GoToNextLevel(); 
    }

    public void StartGame()
    {
        Debug.Log("Start Over");

        level = 1;

        UIManager.Instance.ResetLifes();
        UIManager.Instance.ResetScore();
        EnemyManager.Instance.ClearAllAsteroids();
        ShipManager.Instance.PreInitialize();
        BulletManager.Instance.ClearAllBullets();
        BulletManager.Instance.DestroyAllBullets();
        EnemyManager.Instance.PreInitialize();
        BulletManager.Instance.PreInitialize();

    }

    public void ResetSameLevel()
    {
        Debug.Log("Reset Level");
        EnemyManager.Instance.ClearAllAsteroids();
        BulletManager.Instance.ClearAllBullets();
        ShipManager.Instance.SpawnShip();
        EnemyManager.Instance.PreInitialize();
        
    } 

    public void GoToNextLevel()
    {
        Debug.Log("You win, go to next level");
        BulletManager.Instance.ClearAllBullets();
        BulletManager.Instance.DestroyAllBullets();

        ShipManager.Instance.ResetLifesMax();
        UIManager.Instance.ResetLifes();

        ShipManager.Instance.PreInitialize();
        EnemyManager.Instance.PreInitialize();
        BulletManager.Instance.PreInitialize();

        audioSource.PlayOneShot(Win);
    }

    public void StartOver()
    {
        UIManager.Instance.ResetLifes();

        BulletManager.Instance.ClearAllBullets();
        BulletManager.Instance.DestroyAllBullets();

        ShipManager.Instance.PreInitialize();

        EnemyManager.Instance.StartOver();
        EnemyManager.Instance.PreInitialize();

        BulletManager.Instance.PreInitialize();
    }
}
