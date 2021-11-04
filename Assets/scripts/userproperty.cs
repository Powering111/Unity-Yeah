using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userproperty : MonoBehaviour
{
    public float m_DoubleClickSecond = 0.25f;
    private bool m_IsOneClick = false;
    private double m_Timer = 0;
    public GameObject panel;
    public GameObject CreatedObject;
    public InputField inputField_mass;
    public InputField inputField_angle;
    public InputField inputField_width;
    public InputField inputField_height;
    public InputField inputField_rotate;
    public GameObject cross;
    Ray ray = Camera.main.ScreenPointTo.Ray(Input.mousePosition);
    RaycastHit hit;


    void Update()
    {
        panel.SetActive(false);
        if (Physics.Raycast(ray, out hit))
        {
            if (m_IsOneClick && ((Time.time - m_Timer) > m_DoubleClickSecond))
            {
                m_IsOneClick = false;
            }

            if (hit.transform.gameObject.tag == "CreatedObject")
            {
                if (!m_IsOneClick)
                {
                    m_Timer = Time.time; m_IsOneClick = true;
                }
                else if (m_IsOneClick && ((Time.time - m_Timer) < m_DoubleClickSecond)) //더블클릭했을 때
                {
                    m_IsOneClick = false;
                    panel.SetActive(true); //패널 띄우기
                }
            }
        }
    }


    private float width;
    public void width()
    {
        float.TryParse(widthInput.GetComponent<InputField>().text, out width);
        float height = transform.localScale.y;
        CreatedObject.transform.localScale = new Vector3(width, height, 0);
    }
    private float height;
    public void height()
    {
        float.TryParse(heightInput.GetComponent<InputField>().text, out height);
        float width = transform.localScale.x;
        CreatedObject.transform.localScale = new Vector3(width, height, 0);

    }

    private float mass;
    public void mass()
    {
        float.TryParse(massInput.GetComponent<InputField>().text, out mass);
        CreatedObject.GetComponent<Rigidbody2D>().mass = mass;
    }


    private float rotate;
    public void rotate()
    {
        float.TryParse(rotateInput.GetComponent<InputField>().text, out rotate);

        CreatedObject.transform.Rotate(0, 0, rotate);

    }
    private float angle;
    public void angle()
    {
        float.TryParse(angleInput.GetComponent<InputField>().text, out angle);
        float angle_rad = (angle * Mathf.PI / 180);
        float width = transform.localScale.x;
        float height = width * tan(angle_rad);
        CreatedObject.transform.localScale = new Vector3(width, height, 0);
    }

    void execution()
    {
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "inputField_width")
                width();
            else if (hit.transform.gameObject.tag == "inputField_height")
                height();
            else if (hit.transform.gameObject.tag == " inputField_mass")
                mass();
            else if (hit.transform.gameObject.tag == "inputField_rotate")
                rotate();
            else if (hit.transform.gameObject.tag == "inputField_angle")
                angle();

        }
    }
}


