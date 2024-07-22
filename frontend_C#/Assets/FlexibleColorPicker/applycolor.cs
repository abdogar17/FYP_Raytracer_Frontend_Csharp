using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applycolor : MonoBehaviour
{
    public FlexibleColorPicker fcp;
    public Material material;
    public static applycolor Instance;
    public bool ApplyNow, Allow;
    private void Awake()
    {
        Instance = this;
        ApplyNow = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if (material && ApplyNow && Allow)
        {
            material.color = fcp.color;
        }

    }
    public void AllowToApply()
    {
        ApplyNow = true;
        //  material = null;
    }
    public void DeniedToApply()
    {
        ApplyNow = false;
        Allow = false;
        //  material = null;
    }
    public void NewAssignedMat(Material Newmat)
    {
        material = Newmat;
    }
}
