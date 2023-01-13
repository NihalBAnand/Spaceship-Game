using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CameraAnchorSelector : MonoBehaviour
{
    public FarCameraController anchoredCamera;

    public TMPro.TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] bodies = GameObject.FindGameObjectsWithTag("CelestialBodies");
        List<string> names = new List<string>();
        foreach (GameObject body in bodies)
        {
            names.Add(body.name);
        }
        Debug.Log(names[2]);
        dropdown.AddOptions(names);
        
    }

    // Update is called once per frame
    void Update()
    {
        anchoredCamera.anchor = GameObject.Find(dropdown.options[dropdown.value].text);
        
    }
}
