using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaySlider : MonoBehaviour
{
    public SphereLogic SphereLogic;
    public Slider slider;
    float sliderValue;
    public void Update()
    {

        //Debug.Log("Slider Value: " + sliderValue);

    }

    public void UpdateValue()
    {
       sliderValue = slider.value;
       SphereLogic.UpdateRayLength(sliderValue);
    }


}
