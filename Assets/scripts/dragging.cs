using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragging : MonoBehaviour
{
    private bool selected = false;
    private Vector2 offset;
    private GameObject selectedObject;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse down");
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit= Physics2D.Raycast(ray, Vector2.zero);
            if (hit.collider!=null)
            {
                selectedObject=hit.transform.gameObject;
                offset = new Vector2(hit.transform.position.x,hit.transform.position.y) - ray;
                selected = true;
            }

        }
        else if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
        else if (selected && Input.GetMouseButton(0))
        {
            if (selected)
            {
                Vector2 mousePos = Input.mousePosition;
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                selectedObject.transform.position = worldPos + offset;

            }
        }
    }
}
