using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class panel : MonoBehaviour
{
    private GameObject selectedObject;
    public InputField nameInput, massInput, widthInput, heightInput, angleInput, rotateInput, kInput;
    private bool active=true;
    public void Activate()
    {
        active = true;
    }
    public void Deactivate()
    {
        active = false;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void selectionChange(GameObject obj)
    {
        show();
        if (obj.transform.parent.tag == "force")
        {
            // force
            selectedObject = obj;
            string name = selectedObject.transform.parent.GetComponent<force>().getTargetName();
            float power = selectedObject.transform.parent.GetComponent<force>().getPower();

            nameInput.text = name;
            massInput.text = power.ToString();
        }
        else
        {
            // object
            selectedObject = obj;
            string name = selectedObject.transform.parent.name;
            float mass = selectedObject.GetComponent<Rigidbody2D>().mass;
            massInput.text = mass.ToString();
            nameInput.text = name;
            widthInput.text = selectedObject.transform.localScale.x.ToString();
            heightInput.text = selectedObject.transform.localScale.y.ToString();

            rotateInput.text = selectedObject.transform.eulerAngles.z.ToString();
            
            float f = selectedObject.GetComponent<SpringJoint2D>().frequency;
            kInput.text = (10.194 * f * f - 7.652 * f + 1.3848).ToString();
            gameObject.SetActive(true);
        }
    }

    public void deselect()
    {
        hide();
        selectedObject = null;
        gameObject.SetActive(false);
    }

    public void massChanged()
    {
        if (active)
        {
            if (selectedObject.transform.parent.tag == "force")
            {
                float power;
                float.TryParse(massInput.text, out power);

                selectedObject.transform.parent.GetComponent<force>().setPower(power);
            }
            else
            {
                float mass;
                float.TryParse(massInput.text, out mass);
                if (mass != 0)
                {
                    selectedObject.GetComponent<Rigidbody2D>().mass = mass;
                    if (mass >= 1000.0f)
                    {
                        selectedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    }
                    else
                    {
                        selectedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                    }
                }
            }
        }
    }

    public void nameChanged()
    {
        if (active)
        {
            if (selectedObject.tag == "force")
            {

            }
            else
            {
                string name = nameInput.text;
                if (name.Length > 0)
                {
                    selectedObject.transform.parent.name = name;
                }
            }
        }
    }


    public void width()
    {
        float width = selectedObject.transform.localScale.x;
        float height = selectedObject.transform.localScale.y;
        Debug.Log(string.Format("{0}, {1}",width, height));
        float.TryParse(widthInput.GetComponent<InputField>().text, out width);
        selectedObject.transform.localScale = new Vector3(width, height, 0);
    }
    public void height()
    {
        float width = selectedObject.transform.localScale.x;
        float height = selectedObject.transform.localScale.y;
        Debug.Log(string.Format("{0}, {1}", width, height));
        float.TryParse(heightInput.GetComponent<InputField>().text, out height);
        selectedObject.transform.localScale = new Vector3(width, height, 0);

    }


    public void rotate()
    {
        float rotate=0;
        float.TryParse(rotateInput.GetComponent<InputField>().text, out rotate);
        Debug.Log("rotate");
        selectedObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotate));

    }
    public void angle()
    {
        float angle=45;
        if(!float.TryParse(angleInput.GetComponent<InputField>().text, out angle))
        {
            angle = 45;
        }
        float angle_rad = (angle * Mathf.PI / 180);
        float width = transform.localScale.x;
        float height = width * Mathf.Tan(angle_rad);
        selectedObject.transform.localScale = new Vector3(width, height, 0);
    }

    public void k()
    {
        float k = 0;
        float.TryParse(kInput.GetComponent<InputField>().text, out k);
        float frequency = (float)((Math.Sqrt(5) * Math.Sqrt(12742500 * k + 652031) + 9565) / 25485);
        selectedObject.GetComponent<SpringJoint2D>().frequency = frequency;
        
    }


    public void hide(){
        gameObject.SetActive(false);
    }

    public void show(){
        gameObject.SetActive(true);
    }
}
