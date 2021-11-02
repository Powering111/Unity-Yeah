using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vector : MonoBehaviour
{
    public GameObject Obj;
    public Vector3 Direction;
    // Update is called once per frame
    void Update()
    {
        transform.position = Obj.transform.position;
        Quaternion rot = transform.rotation;
        rot.z = Mathf.Atan(Direction.y/Direction.x)+90;
        transform.rotation = rot;
    }
}
