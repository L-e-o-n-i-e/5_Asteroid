using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner
{
    public List<GameObject> AsteroidsPrefabs = new List<GameObject>();
    public GameObject asteroidPrefab;

    public float asteroidBiggestSize = 2;
    public float asteroidMiddleSize = 1;
    public float asteroidSmallSize = 0.5f;

    public float acceptableDistance = 2;
    Transform parentOfAllAsteroids;
    bool parentCreated = false;

    public List<IFlow> StartLevel(int nbAsteroids, int nbAliens = 0)
    {
        //Organisation in the hierarchie
        if (parentCreated == false)
        {
            parentOfAllAsteroids = new GameObject("Asteroids").transform;
            parentCreated = true;
        }

        //spawn asteroids
        List<IFlow> list = new List<IFlow>();

        for (int i = 0; i < nbAsteroids; i++)
        {
            IFlow iflow = SpawnAsteroid(Asteroids.Level.Biggest, new Vector2(0, 0));
            list.Add(iflow);
        }

        //spawn aliens eventually
        if (nbAliens != 0)
        {

        }

        return list;
    }

    public IFlow SpawnAsteroid(Asteroids.Level size, Vector2 position)
    {
        GameObject goClone = GameObject.Instantiate(asteroidPrefab);
        Asteroids asteroid = goClone.GetComponent<Asteroids>();

        //Set the parent in the hierarchie
        goClone.transform.SetParent(parentOfAllAsteroids);

        switch (size)
        {
            case Asteroids.Level.Biggest:
                
                goClone.transform.position = GetRandomPos();
                asteroid.level = Asteroids.Level.Biggest;
                goClone.transform.localScale = new Vector2(asteroidBiggestSize, asteroidBiggestSize);

                break;

            case Asteroids.Level.Middle:

                goClone.transform.position = position;
                asteroid.level = Asteroids.Level.Middle;
                goClone.transform.localScale = new Vector2(asteroidMiddleSize, asteroidMiddleSize);
                
                break;

            case Asteroids.Level.Small:
                goClone.transform.position = position;
                asteroid.level = Asteroids.Level.Small;
                goClone.transform.localScale = new Vector2(asteroidSmallSize, asteroidSmallSize);
                break;

            default:
                break;
        }

        asteroid.SetDirection(goClone.GetComponent<Rigidbody2D>());
      
        return goClone.GetComponent<IFlow>();
    }

    public void ClearAllAsteroids()
    {
        GameObject.Destroy(parentOfAllAsteroids.gameObject);
        parentCreated = false;
    }

    public Transform GetParentOfAllAsteroids()
    {
        return parentOfAllAsteroids;
    }

    public Vector2 GetRandomPos()
    {
        bool foundAPos = false;
        Vector2 spawnPos;

        int i = 0;
        while (foundAPos == false && i< 10)
        {
            float x = Random.Range(-10, 10f);
            float y = Random.Range(-5, 5f);
            spawnPos = new Vector2(x, y);


            if (Vector2.Distance(spawnPos, Vector2.zero) > acceptableDistance)
            {
                foundAPos = true;
                return spawnPos;
            }
            i++;
        }
        return new Vector2(4, 4);

    }

    
}