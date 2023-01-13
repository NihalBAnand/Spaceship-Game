using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnchorDistanceSlider : MonoBehaviour
{
    public FarCameraController camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.distanceToAnchor = GetComponent<Slider>().value;
    }
}
