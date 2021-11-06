using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Simulator : MonoBehaviour
{
    public GameObject objectGenerator, Panel, playBtn;
    public Sprite playBtnImg, pauseBtnImg;
    private bool active=false;

    void Start()
    {
        Time.timeScale = 1.0f;
    }
    void LateUpdate()
    {
        if (active)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0.0f;
        }
    }
    public void toggle()
    {
        if (!active)
        {
            play();
        }
        else
        {
            pause();
        }
    }

    public void play() {
        if (!active) {
            active = true;
            objectGenerator.GetComponent<ObjectGenerator>().Deactivate();
            objectGenerator.GetComponent<dragging>().Deactivate();

            playBtn.GetComponent<Image>().sprite = pauseBtnImg;
            playBtn.GetComponent<Button>().onClick.RemoveListener(play);
            playBtn.GetComponent<Button>().onClick.AddListener(pause);

            Panel.GetComponent<panel>().Deactivate();
        }
    }

    public void pause()
    {
        if (active)
        {
            active = false;
            objectGenerator.GetComponent<ObjectGenerator>().Activate();
            objectGenerator.GetComponent<dragging>().Activate();
            playBtn.GetComponent<Image>().sprite = playBtnImg;
            playBtn.GetComponent<Button>().onClick.RemoveListener(pause);
            playBtn.GetComponent<Button>().onClick.AddListener(play);

            Panel.GetComponent<panel>().Activate();
        }
    }
}
