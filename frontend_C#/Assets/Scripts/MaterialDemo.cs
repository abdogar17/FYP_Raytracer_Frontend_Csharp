using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MaterialDemo : MonoBehaviour {
    Material SphereMaterial;
    public FlexibleColorPicker fcp;
    public Material material;
 
	// Use this for initialization
	void Update () {
        SphereMaterial = Resources.Load<Material>("BedsV1mat");
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        // Get the current material applied on the GameObject
        Material oldMaterial = meshRenderer.material;
        Debug.Log("Applied Material: " + oldMaterial.name);
        // Set the new material on the GameObject
        material.color = fcp.color;
	}
}
