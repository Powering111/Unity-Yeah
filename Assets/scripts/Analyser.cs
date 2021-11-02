using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analyser : MonoBehaviour
{

    private Vector3 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity=gameObject.GetComponent<Rigidbody2D>().velocity;
        Vector3 acceleration = (velocity - lastVelocity) / Time.deltaTime;;
        float mass = gameObject.GetComponent<Rigidbody2D>().mass;
        Debug.Log(acceleration);
    }
}
