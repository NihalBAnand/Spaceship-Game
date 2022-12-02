using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearCameraController : MonoBehaviour
{
    GameObject camPos;

    public float sens;
    // Start is called before the first frame update
    void Start()
    {
        camPos = GameObject.Find("CameraPosition");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camPos.transform.position;
        transform.rotation = camPos.transform.rotation;

        GameObject.Find("Player").transform.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X")) * sens;
        camPos.transform.eulerAngles += new Vector3(Input.GetAxis("Mouse Y") * -1 * sens, 0);
    }
}
