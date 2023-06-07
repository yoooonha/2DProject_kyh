using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSetting : MonoBehaviour
{
    void Start()
    {
        Player._instance._Hpbar = GetComponent<Slider>();
    }

   
}
