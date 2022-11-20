using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ship : MonoBehaviour, IFlow
{
    Rigidbody2D rb;
    public float speed = 10;
    public float torque = 10;
    public Transform tip;
    float timeBeforeShoot = 0.2f;
    float timeOfSpawn;

    #region Thrust
    bool trhustOn = false;
    Sprite thrust;
    public float maxThrust = 1;
    public float minThrust = 0;
    public float thrustScale = .3f;
    #endregion

    #region Audio
    AudioSource audioSource;
    #endregion

    public void PreInitialize()
    {
        rb = GetComponent<Rigidbody2D>();
        thrust = GetComponent<SpriteRenderer>().sprite;
        audioSource = GetComponent<AudioSource>();
    }

    public void Initialize()
    {
    }

    public void Refresh()
    {

        #region Commentaire Thrust
        //if (trhustOn)
        //{
        //    //limit max
        //    if (thrust.transform.localScale.y < maxThrust)
        //    {
        //        thrust.transform.localScale = thrust.transform.localScale + new Vector3(0, thrustScale * Time.deltaTime, 0);
        //        audioSource.loop = true;
        //    }
        //}
        //else
        //{
        //    if (thrust.transform.localScale.y > minThrust)
        //    {
        //        thrust.transform.localScale = thrust.transform.localScale - new Vector3(0, thrustScale * Time.deltaTime, 0);
        //        audioSource.loop = false;
        //    }

        //}  
        #endregion

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddTorque(torque);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddTorque(-torque);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time - timeOfSpawn >= timeBeforeShoot)
            {
                Shoot();
            }
        }

        if (gameObject != null)
        {
            Vector3 pos = transform.position;
            //Camera Size, OnTriggerEnter, reposition
            if (pos.x < -9 || pos.x > 9 || pos.y < -5 || pos.y > 5)
            {
                transform.position = new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), 0) * -1;
                transform.localEulerAngles += new Vector3(0,0,0.5f);
            }
        }
    }

    public void PhysicsRefresh()
    {
        //caching input of the player and verifiy if it has been used to call physics functions in here.
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector2.up * speed);

            //TODO: Image des thrust qui grandit avec la force
            //ThrustOn() qui change scale de thrust et appelle le sound
        }
    }

    public void EndGame()
    {
    }

    public void Shoot()
    {
        timeOfSpawn = Time.time;

        BulletManager.Instance.SpawnBullet(rb, tip);

    }
}