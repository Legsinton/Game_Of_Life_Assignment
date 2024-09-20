using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Info_Script : MonoBehaviour
{
    public Slider GetSlider;
    public Slider InputField;

    void Start()
    {
        QualitySettings.vSyncCount = 5;


    }

    

    public void SetFrameRate(float value)
    {

        int frameRate = Mathf.RoundToInt(value);
        Application.targetFrameRate = frameRate;




    }



}
