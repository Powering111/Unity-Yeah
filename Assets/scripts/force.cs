using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force : MonoBehaviour
{
    public Transform Target;
    public Vector3 Direction=new Vector3(1,0,0);
    public float Power=9.8f;
    // Update is called once per frame
    void Start()
    {
        Power = 9.8f;
    }
    void Update()
    {
        transform.position = Target.position;
    }
    void FixedUpdate()
    {
        Target.gameObject.GetComponent<Rigidbody2D>().AddForce(Direction * Power,ForceMode2D.Force);
    }

    void applyRotation()
    {
        Quaternion rot = transform.rotation;
        rot.z = Mathf.Atan(Direction.y / Direction.x) + 90;
        transform.rotation = rot;
    }
    public GameObject getTarget()
    {
        return this.Target.gameObject;
    }
    public void setTarget(Transform target)
    {
        this.Target = target;
        applyRotation();
    }

    public void select()
    {
        Target.gameObject.GetComponent<outline>().OnEnable();
    }
    
    public string getTargetName()
    {
        return Target.parent.gameObject.name;
    }
    public float getPower()
    {
        return this.Power;
    }
    public void setPower(float power)
    {
        this.Power = power;
    }
}
