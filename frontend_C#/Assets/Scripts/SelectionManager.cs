using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightedMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;

    void Update(){
        if(_selection != null){
            var selectionRenderer = _selection.GetComponent<Renderer>();
            //selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray , out hit)){
            var selection = hit.transform;
            if(selection.CompareTag(selectableTag)){
                var selectionRenderer = selection.GetComponent<Renderer>();
                if(selectionRenderer != null){
                    selectionRenderer.material = highlightedMaterial;
                }
                _selection = selection;
            }
        }
    }
}
