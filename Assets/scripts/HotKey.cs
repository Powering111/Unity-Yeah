using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKey : MonoBehaviour
{
    private Simulator simulator;
    public dragging dragger;
    void Start()
    {
        simulator = gameObject.GetComponent<Simulator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            simulator.toggle();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            dragger.unsetMulti();
        }
    }
}
