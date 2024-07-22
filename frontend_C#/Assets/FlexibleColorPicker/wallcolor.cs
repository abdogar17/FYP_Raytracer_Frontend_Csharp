using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallcolor : MonoBehaviour
{
    public FlexibleColorPicker fcp;
    public Material material;

    // Update is called once per frame
    public void Update()
    {



        material.color = fcp.color;

    }
}
