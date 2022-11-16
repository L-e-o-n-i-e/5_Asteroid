using System.Collections;
using System.Timers;
using UnityEngine;

public class Bullet : MonoBehaviour, IFlow

{
    public float speed = 6;
    Rigidbody2D rb;
    IFlow iflow;
    Vector2 position;
    Vector3 eulerAngle;
    float timeOnSpawn;
    float timeBeforeDelete = 2.5f;


    public void PreInitialize()
    {
        Debug.Log("Bullet PreInitialize");

        iflow = gameObject.GetComponent<IFlow>();
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    public void Initialize()
    {
        timeOnSpawn = Time.time;
        rb.velocity = rb.transform.up * speed;
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

            if (Time.time - timeOnSpawn >= timeBeforeDelete)
            {
                Delete();
            }
        }
    }

    public void PhysicsRefresh()
    {
        //Debug.Log("Bullet PhysicsRefresh");
    }

    public void EndGame()
    {
    }

    public void Delete()
    {
        BulletManager.Instance.PutOnTheRemoveList(iflow);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Delete();
    }
}