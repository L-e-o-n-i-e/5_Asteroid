using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ship : MonoBehaviour, IFlow
{
    Rigidbody2D rb;
    public float speed = 10;
    public float torque = 10;

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
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector2.up * speed);

            //TODO: Image des thrust qui grandit avec la force
            //ThrustOn() qui change scale de thrust et appelle le sound
        }
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
               
        if (Input.GetKey(KeyCode.A ) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(torque);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-torque);
        }
    }

    public void PhysicsRefresh()
    {
        //caching input of the player and verifiy if it has been used to call physics functions in here.
    }

    public void EndGame()
    {
    }
}