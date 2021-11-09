using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 lastPos;
    public float multiplier;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = new Vector3(0, 0, 0);
        multiplier = 0.0225f;
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
            transform.position += offset*multiplier;
            lastPos = mousePos;
        }
    }
}
