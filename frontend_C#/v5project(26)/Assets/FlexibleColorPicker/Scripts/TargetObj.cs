using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObj : MonoBehaviour
{
    private Renderer renderer;
    public FlexibleColorPicker fcp;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver(){
        //renderer.material.color = Color.red;
        if(Input.GetKeyDown("space")){
            mat.color = Color.red;
            print("A was pressed");
        }
           
    }
    private void OnMouseExit(){
        //renderer.material.color = Color.white;
        mat.color = Color.white;
    }
}
