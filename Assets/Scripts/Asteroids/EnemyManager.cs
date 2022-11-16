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

    //Mon enemy Manager pourrait faire un ressources/load
    private int nbAsteroidToSpawn = 4;
    private EnemySpawner enemySpawner;
    private Vector2 positionToSpawn;
    private List<IFlow> iflowList;

    public void AddAsteroid(GameObject goPrefab)
    {        
        if (enemySpawner == null)
        {
            enemySpawner = new EnemySpawner();
        }

        enemySpawner.AsteroidsPrefabs.Add(goPrefab);
    }

    public void PreInitialize()
    {
        Debug.Log("Instance of EnemyManager");


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

    public void SpawnAsteroid(Asteroids.Level size, Vector2 pos)
    {
        enemySpawner.SpawnAsteroid(size, pos);
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

    public void AllEnemiesDied()
    {
        int level = LevelManager.Instance.IncreaseLevel();
        //reset new level with nb of asteroids according to it
        //call to ShipManager to reset for a new level
    }
}