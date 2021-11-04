using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class delete : MonoBehaviour
{

    public GameObject CreatedObject;
    
    void Update()
    {
        void Erase ()
        {
           private Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            private RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "CreatedObject")
                {
                    Destroy(CreatedObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            private Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            private RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null && hit.collider.transform == thisTransform)
            {
                Erase();
            }
        }

      


    
    }
}
