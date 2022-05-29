using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorToolAdd : LevelEditorTool
{
    public GameObject prefab;
    private GameObject selectedObject;

    override
    public void Initialize() {

    }

    override
    public void OnClick() {
        Debug.Log("Tool click");
        if (selectedObject == null) {
            var worldPosition = GetMousePosition(); 
            selectedObject = Instantiate(prefab, worldPosition, Quaternion.identity);
            if ((selectedObject.tag).Equals("Untagged")) {
                selectedObject.tag = "Uncolored";
            }
        } else {
            selectedObject = null;
        }
    }

    public void Update() {
        if (selectedObject != null) {
            var mousePos = GetMousePosition();
            selectedObject.transform.position = new Vector3(mousePos.x, mousePos.y, selectedObject.transform.position.z);
        }
    }
}
