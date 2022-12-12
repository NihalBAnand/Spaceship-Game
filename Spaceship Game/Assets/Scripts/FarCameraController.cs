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
            //Save the current position, and move to the origin
            Vector3 oldPosition = transform.position;
            transform.position = new Vector3(0, 0, 0);

            //Get all far camera objects, and move them to be in the same positions relative to the far camera
            GameObject[] objects = GameObject.FindGameObjectsWithTag("CelestialBodies");
            foreach (GameObject obj in objects)
            {
                Vector3 newPosition = obj.transform.position - oldPosition;
                obj.transform.position = newPosition;
            }
        }
    }
}
