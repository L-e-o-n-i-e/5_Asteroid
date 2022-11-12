using UnityEngine;

public class Asteroids : MonoBehaviour, IFlow
{
    public float speed = 20;
    public float torque = 10;

    Rigidbody2D rb;

    public void PreInitialize()
    {
        float x = Random.Range(-1, 1f);
        float y = Random.Range(-1, 1f);

        rb = GetComponent<Rigidbody2D>();
        rb.velocity =  new Vector2(x, y).normalized * speed;
    }

    public void Initialize()
    {
    }

    public void Refresh()
    {
    }

    public void PhysicsRefresh()
    {
        // Attention, Rb ne collisionne pas avec le rb d'un autre asteroid. Seulement avec le ship.
    }

    public void EndGame()
    {
    }
}
