using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeGravityBody : MonoBehaviour
{
    static float SIMULATION_SPEED = 500000;
    static float GRAVITATIONAL_CONSTANT = 6.6743f * Mathf.Pow(10, -11);
    static float SCALE = 10000000f;

    public static List<LargeGravityBody> bodies = new List<LargeGravityBody>();

    public float mass;

    public float realtimeHoursPerRotation;

    Vector3 velocityVector;

    public GameObject satelliteOf;

    
    // Start is called before the first frame update
    void Start()
    {
        bodies.Add(this);

        if (satelliteOf != null)
        {
            velocityVector = Vector3.Cross((transform.position * SCALE - satelliteOf.transform.position * SCALE), Vector3.up).normalized;
            
            float startingVelocity = Mathf.Pow(GRAVITATIONAL_CONSTANT * satelliteOf.GetComponent<LargeGravityBody>().mass / Vector3.Distance(transform.position * SCALE, satelliteOf.transform.position * SCALE), 0.5f);
            Debug.Log(gameObject.name + " " + startingVelocity);
            velocityVector *= startingVelocity;
            
        }
        else
        {
            velocityVector = new Vector3(0, 0, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate around the axis
        float rotateSpeed = (360 / (realtimeHoursPerRotation * 3600)) * SIMULATION_SPEED;
        transform.RotateAround(transform.position, transform.forward, rotateSpeed * Time.deltaTime);
        Vector3 accelVector = new Vector3();
        foreach (LargeGravityBody body in bodies)
        {
            if (body == this)
            {
                continue;
            }
            float forceOfGravity = GRAVITATIONAL_CONSTANT * ((mass * body.mass) / Mathf.Pow(Vector3.Distance(transform.position * SCALE, body.gameObject.transform.position * SCALE), 2));
            float acceleration = (forceOfGravity / mass);
            
            accelVector += (body.gameObject.transform.position * SCALE - transform.position * SCALE).normalized * acceleration;
        }
        //if (gameObject.name == "Mercury")
        //{
        //    Debug.Log(accelVector.z);
        //}
        velocityVector += accelVector * Time.deltaTime;
        transform.Translate((velocityVector / SCALE) * Time.deltaTime * SIMULATION_SPEED);
    }
}
