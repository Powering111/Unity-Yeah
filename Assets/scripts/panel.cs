using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panel : MonoBehaviour
{
    private GameObject selectedObject;
    public InputField nameInput, massInput;
    private bool active;
    public void Activate()
    {
        nameInput.ActivateInputField();
        massInput.ActivateInputField();
        active = true;
    }
    public void Deactivate()
    {
        nameInput.DeactivateInputField();
        massInput.DeactivateInputField();
        active = false;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void selectionChange(GameObject obj)
    {
        selectedObject = obj;
        float mass = selectedObject.GetComponent<Rigidbody2D>().mass;
        string name = selectedObject.transform.parent.name;
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
            if (mass == 0) mass = 1;
            selectedObject.GetComponent<Rigidbody2D>().mass = mass;
        }
    }

    public void nameChanged()
    {
        if (active)
        {
            string name = nameInput.text;
            if (name.Length > 0)
            {
                selectedObject.transform.GetChild(0).name = name;
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
