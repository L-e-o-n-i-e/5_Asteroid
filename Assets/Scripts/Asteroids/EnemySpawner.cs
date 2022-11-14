using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class EnemySpawner
{
    public List<GameObject> AsteroidsPrefabs = new List<GameObject>();
    public float asteroidBiggestSize = 2;
    public float asteroidMiddleSize = 1;
    public float asteroidSmallSize = 0.5f;

    public List<IFlow> StartLevel(int nbAsteroids, int nbAliens = 0)
    {
        //spawn asteroids
        List<IFlow> list = new List<IFlow>();

        for (int i = 0; i < nbAsteroids; i++)
        {
            IFlow iflow = SpawnBiggestAsteroid();
            list.Add(iflow);
        }
        //spawn aliens eventually
        if (nbAliens != 0)
        {

        }

        return list;
    }

    public IFlow SpawnBiggestAsteroid()
    {
        IFlow iflow;
        float x = Random.Range(-10, 10f);
        float y = Random.Range(-5, 5f);
        int index = 0;

        GameObject asteroid = GameObject.Instantiate(AsteroidsPrefabs[index]);
        iflow = asteroid.GetComponent<IFlow>();
        asteroid.GetComponent<Asteroids>().level = Asteroids.Level.Biggest;

        asteroid.transform.position = new Vector2(x, y);
        asteroid.transform.localScale = new Vector2(asteroidBiggestSize, asteroidBiggestSize);

        return iflow;
    }

    public IFlow SpawnMiddleAsteroid(Vector2 position)
    {
        IFlow iflow;
        int index = 0;

        GameObject go = GameObject.Instantiate(AsteroidsPrefabs[index]);
        iflow = go.GetComponent<IFlow>();
        Asteroids asteroid = go.GetComponent<Asteroids>();
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();

        asteroid.level = Asteroids.Level.Middle;
        go.transform.position = position;
        asteroid.SetSize();
        asteroid.SetDirection(rb);

        return iflow;
    }

    public IFlow SpawnSmallAsteroid(Vector2 position)
    {
        IFlow iflow;
        int index = 0;

        GameObject go = GameObject.Instantiate(AsteroidsPrefabs[index]);
        iflow = go.GetComponent<IFlow>();
        Asteroids asteroid = go.GetComponent<Asteroids>();
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();

        asteroid.level = Asteroids.Level.Small;
        go.transform.position = position;
        asteroid.SetSize();
        asteroid.SetDirection(rb);

        return iflow;
    }
}