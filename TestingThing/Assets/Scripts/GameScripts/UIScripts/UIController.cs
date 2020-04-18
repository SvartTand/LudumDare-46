using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Gun currentGun;
    public Text angleText;
    public Slider angleSlider;

    private void Start()
    {
        angleText.text = "Angle: " + angleSlider.value;
        currentGun.SetAngle(angleSlider.value);
    }

    public void FirePressed()
    {
        currentGun.Fire();
    }

    public void AngleSliderChanged()
    {
        angleText.text = "Angle: " + angleSlider.value;
        currentGun.SetAngle(angleSlider.value);
    }
	
}
