using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CelestialBodyLocationIndicator : MonoBehaviour
{
    public List<GameObject> celestialBodies;

    Vector3 smallestPos = new Vector3(999999999999999, 9999999999999999, 9999999999999999);
    GameObject smallestPosGO;
    Vector3 largestPos = new Vector3(0, 0, 0);
    GameObject largestPosGO;

    public float distanceScalar;
    public float gasGiantSizeScalar;
    public float terrestrialSizeScalar;
    public float moonSizeScalar;
    public float sunSizeScalar;

    public GameObject indicatorPrefab;
    // Start is called before the first frame update
    void Start()
    {
        celestialBodies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        celestialBodies.Clear();

        foreach (LargeGravityBody body in LargeGravityBody.bodies)
        {
            celestialBodies.Add(body.gameObject);
            if (Mathf.Abs(body.gameObject.transform.position.magnitude) < Mathf.Abs(smallestPos.magnitude))
            {
                smallestPos = body.gameObject.transform.position;
                smallestPosGO = body.gameObject;
            }
            if (Mathf.Abs(body.gameObject.transform.position.magnitude) > Mathf.Abs(largestPos.magnitude))
            {
                largestPos = body.gameObject.transform.position;
                largestPosGO = body.gameObject;
            }
            //Debug.Log(largestPos);
        }

        float xrange = Mathf.Abs(largestPos.x) - Mathf.Abs(smallestPos.x);
        if (xrange == 0)
            xrange = 1;
        float yrange = Mathf.Abs(largestPos.y) - Mathf.Abs(smallestPos.y);
        if (yrange == 0)
            yrange = 1;
        float zrange = Mathf.Abs(largestPos.z) - Mathf.Abs(smallestPos.z);
        if (zrange == 0)
            zrange = 1;

        foreach (GameObject body in celestialBodies)
        {
            GameObject newCircle = Instantiate(indicatorPrefab);
            newCircle.transform.SetParent(gameObject.transform, false);
            newCircle.name = body.name + "Indicator";

            

            //Vector3 normalizedWorldPos = new Vector3(2 * ((Mathf.Abs(body.transform.position.x) - Mathf.Abs(smallestPos.x)) / xrange) - 1, 2 * ((Mathf.Abs(body.transform.position.z) - Mathf.Abs(smallestPos.z)) / zrange) - 1);

            //newCircle.transform.localPosition = normalizedWorldPos * distanceScalar;
            //Debug.Log(body.name + " pos: " + normalizedWorldPos);


            newCircle.transform.localPosition = new Vector3(body.transform.position.x / distanceScalar, body.transform.position.z / distanceScalar);

            switch (body.name)
            {
                case "Sun":
                    newCircle.GetComponent<Image>().color = new Color(241 / 255f, 255 / 255f, 89 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / sunSizeScalar;
                    break;

                case "Mercury":
                    newCircle.GetComponent<Image>().color = new Color(117 / 255f, 111 / 255f, 95 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / terrestrialSizeScalar;
                    break;

                case "Venus":
                    newCircle.GetComponent<Image>().color = new Color(117 / 255f, 111 / 255f, 95 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / terrestrialSizeScalar;
                    break;

                case "Earth":
                    newCircle.GetComponent<Image>().color = new Color(117 / 255f, 111 / 255f, 95 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / terrestrialSizeScalar;
                    break;
                case "Luna":
                    newCircle.GetComponent<Image>().color = new Color(117 / 255f, 111 / 255f, 95 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / terrestrialSizeScalar;
                    break;

                case "Mars":
                    newCircle.GetComponent<Image>().color = new Color(117 / 255f, 111 / 255f, 95 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / terrestrialSizeScalar;
                    break;
                case "Phobos":
                    newCircle.GetComponent<Image>().color = new Color(117 / 255f, 111 / 255f, 95 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / terrestrialSizeScalar;
                    break;
                case "Deimos":
                    newCircle.GetComponent<Image>().color = new Color(117 / 255f, 111 / 255f, 95 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / terrestrialSizeScalar;
                    break;

                case "Jupiter":
                    newCircle.GetComponent<Image>().color = new Color(252 / 255f, 217 / 255f, 189 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / gasGiantSizeScalar;
                    break;
                case "Ganymede":
                    newCircle.GetComponent<Image>().color = new Color(87 / 255f, 87 / 255f, 87 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / moonSizeScalar;
                    break;
                case "Io":
                    newCircle.GetComponent<Image>().color = new Color(87 / 255f, 87 / 255f, 87 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / moonSizeScalar;
                    break;
                case "Callisto":
                    newCircle.GetComponent<Image>().color = new Color(87 / 255f, 87 / 255f, 87 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / moonSizeScalar;
                    break;
                case "Europa":
                    newCircle.GetComponent<Image>().color = new Color(87 / 255f, 87 / 255f, 87 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / moonSizeScalar;
                    break;

                case "Saturn":
                    newCircle.GetComponent<Image>().color = new Color(252 / 255f, 217 / 255f, 189 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / gasGiantSizeScalar;
                    break;
                case "Titan":
                    newCircle.GetComponent<Image>().color = new Color(87 / 255f, 87 / 255f, 87 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / moonSizeScalar;
                    break;
                case "Enceladus":
                    newCircle.GetComponent<Image>().color = new Color(87 / 255f, 87 / 255f, 87 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / moonSizeScalar;
                    break;
                case "Rhea":
                    newCircle.GetComponent<Image>().color = new Color(87 / 255f, 87 / 255f, 87 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / moonSizeScalar;
                    break;

                case "Uranus":
                    newCircle.GetComponent<Image>().color = new Color(252 / 255f, 217 / 255f, 189 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / gasGiantSizeScalar;
                    break;

                case "Neputune":
                    newCircle.GetComponent<Image>().color = new Color(252 / 255f, 217 / 255f, 189 / 255f);
                    newCircle.transform.localScale = body.transform.localScale / gasGiantSizeScalar;
                    break;
            }
        }
    }
}
