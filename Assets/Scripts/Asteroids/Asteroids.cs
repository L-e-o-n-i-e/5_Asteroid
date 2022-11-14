using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Asteroids : MonoBehaviour, IFlow
{
    public float speed = 5;
    public float torque = 10;

    Rigidbody2D rb;

    #region Size
    public enum Level { Biggest, Middle, Small }
    public Level level = Level.Biggest;
    public float biggestSize = 2;
    public float middleSize = 1;
    public float smallSize = 0.5f;
    #endregion 

    public void PreInitialize()
    {
        rb = GetComponent<Rigidbody2D>();
        SetDirection(rb);
        SetSize();
    }

    public void SetSize()
    {
        switch (level)
        {
            case Level.Biggest:
                gameObject.transform.localScale = new Vector3(biggestSize, biggestSize, 1);
                break;
            case Level.Middle:
                gameObject.transform.localScale = new Vector3(middleSize, middleSize, 1);
                break;
            case Level.Small:
                gameObject.transform.localScale = new Vector3(smallSize, smallSize, 1);
                break;
            default:
                break;
        }
    }

    public void SetDirection(Rigidbody2D rb)
    {
        float x = Random.Range(-1, 1f);
        float y = Random.Range(-1, 1f);
        rb.velocity = new Vector2(x, y).normalized * speed;
    }
    public void Initialize()
    {

    }


    public void Refresh()
    {
      
        if (gameObject != null)
        {
            Vector3 pos = transform.position;
            //Camera Size, OnTriggerEnter, reposition
            if (pos.x < -9 || pos.x > 9 || pos.y < -5 || pos.y > 5)
            {
                transform.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0) * -1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(name + "I've been hit");

        EnemyManager.Instance.AsteroidDied(this);
        GameObject.Destroy(gameObject);
    }

    public void PhysicsRefresh()
    {
        Debug.Log("PhysicsRefresh asteroid");
    }




    public void EndGame()
    {
    }
}
