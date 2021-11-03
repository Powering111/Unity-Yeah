using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panel : MonoBehaviour
{
    private GameObject selectedObject;
    public InputField nameInput, massInput;
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
        selectedObject = obj;
        string name = selectedObject.transform.parent.name;
        float mass = selectedObject.GetComponent<Rigidbody2D>().mass;
        massInput.text = mass.ToString();
        nameInput.text = name;

        gameObject.SetActive(true);
    }

    public void deselect()
    {
        selectedObject = null;
        gameObject.SetActive(false);
    }

    public void massChanged()
    {
        if (active)
        {
            float mass;
            float.TryParse(massInput.text, out mass);
            if (mass != 0)
            {
                selectedObject.GetComponent<Rigidbody2D>().mass = mass;
            }
        }
    }

    public void nameChanged()
    {
        if (active)
        {
            string name = nameInput.text;
            if (name.Length > 0)
            {
                selectedObject.transform.parent.name = name;
            }
        }
    }

    public void hide(){
        gameObject.SetActive(false);
    }

    public void show(){
        gameObject.SetActive(true);
    }
}
