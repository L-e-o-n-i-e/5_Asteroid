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


    private int nbAsteroidToSpawn = 4;
    private EnemySpawner enemySpawner;
    private Vector2 positionToSpawn;
    private List<IFlow> listAsterIFlow;

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
        Debug.Log("Je suis Ennemy manager! ");

        listAsterIFlow = enemySpawner.SpawnAsteroid(nbAsteroidToSpawn);

        foreach (var iflow in listAsterIFlow)
        {
            iflow.PreInitialize();
        }
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