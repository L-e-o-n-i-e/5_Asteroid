using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : IFlow
{
    #region Singleton
    private static EnemyManager instance;
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
                instance = new EnemyManager();

            return instance;
        }

    }
    private EnemyManager() { }
    #endregion
    
    private EnemySpawner enemySpawner = new EnemySpawner();
    //private Vector2 positionToSpawn;
    private List<IFlow> iflowList;

    private int NB_ASTEROID_START = 4;
    private int nbAsteroidToSpawn = 4;

    private bool allEnemiesDied = false;

    public void SetAsteroidPrefab(GameObject goPrefab)
    {
        enemySpawner.asteroidPrefab = goPrefab;
    }
  
    public void PreInitialize()
    {
        iflowList = enemySpawner.StartLevel(nbAsteroidToSpawn);

        foreach (var iflow in iflowList)
        {
            iflow.PreInitialize();
        }
    }

    public void Initialize()
    {
        foreach (var iflow in iflowList)
        {
            iflow.Initialize();
        }
    }

    public void Refresh()
    {
        foreach (var iflow in iflowList)
        {
            iflow.Refresh();
        }

        Transform poaa = enemySpawner.GetParentOfAllAsteroids();

        if (poaa.childCount == 0)
        {
            AllEnemiesDied();
        }
    }

    public void PhysicsRefresh()
    {
        foreach (var iflow in iflowList)
        {
            iflow.PhysicsRefresh();
        }
    }

    public void EndGame()
    {
        foreach (var iflow in iflowList)
        {
            iflow.EndGame();
        }
    }

    public void RemoveFromList(IFlow toRemove)
    {
        iflowList.Remove(toRemove);

    }

    public void AddToList(IFlow toAdd)
    {
        iflowList.Add(toAdd);
    }

    public void AsteroidDied(Asteroids dyingAsteroid)
    {
        IFlow iflow = dyingAsteroid.GetComponent<IFlow>();
        Asteroids.Level asteroidLevel = dyingAsteroid.level;
        Vector2 position = dyingAsteroid.transform.position;

        switch (asteroidLevel)
        {
            case Asteroids.Level.Biggest:

                for (int i = 0; i < 2; i++)
                {
                    IFlow toAdd = enemySpawner.SpawnAsteroid(Asteroids.Level.Middle, position);
                    AddToList(toAdd);
                }
                break;
            case Asteroids.Level.Middle:

                for (int i = 0; i < 2; i++)
                {
                    IFlow toAdd = enemySpawner.SpawnAsteroid(Asteroids.Level.Small, position);
                    AddToList(toAdd);
                }
                break;
            case Asteroids.Level.Small:

                break;
            default:
                Debug.Log("AsteroidDied default case.");
                break;
        }

        RemoveFromList(iflow);
    }

    public void ClearAllAsteroids()
    {
        enemySpawner.ClearAllAsteroids();
        iflowList.Clear();
    }

    public void AllEnemiesDied()
    {
        nbAsteroidToSpawn++;
        LevelManager.Instance.IncreaseLevel();
    }

    public void StartOver()
    {
        nbAsteroidToSpawn = NB_ASTEROID_START;
    }
}