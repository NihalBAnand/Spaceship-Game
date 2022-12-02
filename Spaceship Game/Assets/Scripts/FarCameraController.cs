using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarCameraController : MonoBehaviour
{
    public float maxDistanceFromOrigin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(0, 0, 0)) > maxDistanceFromOrigin)
        {
            Vector3 moveAway = transform.position * -1;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), maxDistanceFromOrigin);
            GameObject[] objects = GameObject.FindGameObjectsWithTag("CelestialBodies");
            foreach (GameObject obj in objects)
            {
                obj.transform.position = Vector3.MoveTowards(obj.transform.position, moveAway, maxDistanceFromOrigin);
            }
        }
    }
}
