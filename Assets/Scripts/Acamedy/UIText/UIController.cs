using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Text _level; //Level
    [SerializeField] Text _name; //Name

    // Start is called before the first frame update
    void Start()
    {
        _image.fillAmount = 1f;
        _level.text = "Lv.105";
        _name.text = "younha";
    }

    // Update is called once per frame
   
    public void OnButtonDown()
    {
        Debug.Log("OnButtonDown");
        _image.fillAmount = 0.8f;
        _level.text = "Lv.200";
        _name.text = "KYH";
    }

    public void OnPointerDown() 
    {
        Debug.Log("OnPointerDown");
    }

    public void OnOptionClick()
    {
        Debug.Log("On Option Click");
    }


}


