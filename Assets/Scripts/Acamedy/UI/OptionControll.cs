using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionControll : MonoBehaviour
{
    [SerializeField] Toggle _toggle;
    [SerializeField] Slider _slider;
    [SerializeField] InputField _inputField;

    private void Start()
    {
        _toggle.isOn = false; 
    }
    void Update()
    {

        _slider.value += Time.deltaTime;
        if (_slider.value >= 1) _slider.value = 0;

    }

    public void OnInputFieldChange()
    {
        Debug.Log("InputField change to :" + _inputField.text);
    }

    public void OnToggleChange()
    {
        Debug.Log("Toggle Change to : " + _toggle.isOn);
      
    }

    public void OnSliderValueChange()
    {
        //Debug.Log("Slider value to :" + _slider.value);
    }

}
