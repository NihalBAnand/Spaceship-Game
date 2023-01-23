using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarCameraController : MonoBehaviour
{
    public float maxDistanceFromOrigin;

    public GameObject anchor;
    public float distanceToAnchor;
    // Start is called before the first frame update
    void Start()
    {
        if (anchor != null)
        {
            if (distanceToAnchor == 0)
                distanceToAnchor = Vector3.Distance(transform.position, anchor.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (anchor != null)
        {
            Vector3 direction = (anchor.transform.position - transform.position).normalized;
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case (0):
                        if (direction.x < 0)
                        {
                            direction.x = Mathf.Abs(direction.x);
                        } 
                        break;
                    case (1):
                        if (direction.y < 0)
                        {
                            direction.y = Mathf.Abs(direction.y);
                        }
                        break;
                    case (2):
                        if (direction.z < 0)
                        {
                            direction.z = Mathf.Abs(direction.z);
                        }
                        break;
                }
            }
            //Debug.Log(direction);
            transform.position = anchor.transform.position + (direction * distanceToAnchor);

            transform.LookAt(anchor.transform.position);
        }

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
