using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public Vector3 Direction=new Vector3(1,0,0);
    public Vector3 Position = new Vector3(0, 0, 0);

    void Update()
    {
        transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            Mathf.Atan(Direction.y / Direction.x)*180/(Mathf.PI) + 90 +(Direction.x>=0 ? 180 : 0)
        );
        transform.position = Position;
        
    }
    public void setRotation(Vector3 toward)
    {
        Direction = toward.normalized;
        
    }
    public void setPosition(Vector3 toward)
    {
        Position= toward;
    }

}
