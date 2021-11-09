using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 lastPos;
    public float multiplier;
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = new Vector3(0, 0, 0);
        multiplier = 0.0045f;
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            lastPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(2)) { 
            Vector3 mousePos = Input.mousePosition;
            Vector3 offset = lastPos - mousePos;
            transform.position += offset*multiplier * camera.orthographicSize;
            lastPos = mousePos;
        }

        //Zoom
        if (Input.mouseScrollDelta.y > 0f)
        {
            camera.orthographicSize *= 0.9f;
        }
        if(Input.mouseScrollDelta.y < 0f)
        {
            camera.orthographicSize *= 1.111111f;
        }

        //Reset View
        if (Input.GetKeyDown(KeyCode.Home))
        {
            transform.position = new Vector3(0, 0, 0);
            camera.orthographicSize = 5f;
        }
    }
}
