using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Gun currentGun;
    public Text angleXText;
    public Text angleYText;
    public Slider angleXSlider;
    public Slider angleYSlider;

    private void Start()
    {
        //angleXText.text = "AngleX: " + angleXSlider.value;
        //currentGun.SetAngle(angleXSlider.value, angleYSlider.value);
        //angleYText.text = "AngleY: " + angleYSlider.value;
        //currentGun.SetAngle(angleXSlider.value, angleYSlider.value);
    }

    public void FirePressed()
    {
        currentGun.Fire();
    }

    public void AngleXSliderChanged()
    {
        angleXText.text = "AngleX: " + angleXSlider.value;
        currentGun.SetAngle(angleXSlider.value, angleYSlider.value);
    }
    public void AngleYSliderChanged()
    {
        angleYText.text = "AngleY: " + angleYSlider.value;
        currentGun.SetAngle(angleXSlider.value, angleYSlider.value);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }

}
