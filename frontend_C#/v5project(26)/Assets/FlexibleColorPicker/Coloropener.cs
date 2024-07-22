using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coloropener : MonoBehaviour
{
    public GameObject FlexibleColorPicker;
     public void OpenFlexibleColorPicker()

    {
        if (FlexibleColorPicker != null)
        {
            bool isActive = FlexibleColorPicker.activeSelf;
            FlexibleColorPicker.SetActive(!isActive);
        }
    }
   
    
}
