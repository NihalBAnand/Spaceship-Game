using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeGravityBody : MonoBehaviour
{
    static float GRAVITATIONAL_CONSTANT = 6.6743f * Mathf.Pow(10, -11) * 100000f;

    public static List<LargeGravityBody> bodies = new List<LargeGravityBody>();

    public float mass;
    //public float approxRadius;

    // Start is called before the first frame update
    void Start()
    {
        bodies.Add(this);

        //Vector3 meshBounds = GetComponent<MeshFilter>().mesh.bounds.size;
        //meshBounds = Vector3.Scale(transform.localScale, meshBounds);
        //approxRadius = (meshBounds.x + meshBounds.y + meshBounds.z) / 3 / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, .1f, 0);
    }
}
