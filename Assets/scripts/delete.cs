using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class delete : MonoBehaviour
{

    private bool active=false;
    public Sprite activeImg, notActiveImg;
    public void toggle()
    {
        if (active)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }
    public void Activate()
    {
        active = true;

        gameObject.GetComponent<Image>().sprite = activeImg;
        gameObject.GetComponent<Button>().onClick.RemoveListener(Activate);
        gameObject.GetComponent<Button>().onClick.AddListener(Deactivate);

        
    }

    public void Deactivate()
    {
        active = false;

        gameObject.GetComponent<Image>().sprite = notActiveImg;
        gameObject.GetComponent<Button>().onClick.RemoveListener(Deactivate);
        gameObject.GetComponent<Button>().onClick.AddListener(Activate);
    }

    void Update() {
        if (active && Input.GetMouseButton(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.transform.parent.tag == "body" || hit.transform.parent.tag == "force")
                {
                    Destroy(hit.transform.parent.gameObject);
                }
            }
        }
    }
}