using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorToolAddEntrance : LevelEditorTool
{
    public GameObject prefab;
    private GameObject selectedObject;


    override
        public void Initialize() {

    }

    override
        public void OnClick() {
        
        // Search for other entrances
        GameObject[] entrances = GameObject.FindGameObjectsWithTag("Entrance");
        
        
        Debug.Log(entrances.Length);
        Debug.Log("Tool click");
        if (selectedObject == null && entrances.Length == 0)  {
            var worldPosition = GetMousePosition();
            selectedObject = Instantiate(prefab, worldPosition, Quaternion.identity);
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