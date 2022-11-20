using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsConnector : AbstractConnector
{
    public GameObject asteroidPrefab1;

    public override void Connect()
    {
        EnemyManager.Instance.SetAsteroidPrefab(asteroidPrefab1);
    }
}
