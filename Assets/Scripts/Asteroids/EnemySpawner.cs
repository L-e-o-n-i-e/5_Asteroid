using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner 
{
    public List<GameObject> AsteroidsPrefabs = new List<GameObject>();

    public List<IFlow> SpawnAsteroid(int nbToSpawn)
    {
        List<IFlow> list = new List<IFlow>();

        for (int i = 0; i < nbToSpawn; i++)
        {
            IFlow interfAsteroid;
            float x = Random.Range(-10, 10f);
            float y = Random.Range(-5, 5f);
            int index = Random.Range(0, 4);
            
            GameObject asteroid = GameObject.Instantiate(AsteroidsPrefabs[index]);

            interfAsteroid = asteroid.GetComponent<IFlow>();

            //TODO make sure not to spawn on the ship!
            asteroid.transform.position = new Vector2(x, y);

            list.Add(interfAsteroid);
        }
        return list;
    }   
}