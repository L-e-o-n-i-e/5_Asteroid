using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsConnector : AbstractConnector
{
    //connecte les gameObjects(prefabs) avec les managers
    public GameObject asteroidPrefab1;
    public GameObject asteroidPrefab2;
    public GameObject asteroidPrefab3;
    public GameObject asteroidPrefab4;
    

    public override void Connect()
    {
        EnemyManager.Instance.AddAsteroid(asteroidPrefab1);
        EnemyManager.Instance.AddAsteroid(asteroidPrefab2);
        EnemyManager.Instance.AddAsteroid(asteroidPrefab3);
        EnemyManager.Instance.AddAsteroid(asteroidPrefab4);
    }
}
