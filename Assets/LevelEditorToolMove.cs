using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorToolMove : LevelEditorTool
{
    private BoxCollider2D[] colliders;
    GameObject selectedObject;

    override
    public void Initialize() {
        selectedObject = null;
    }

    override
    public void OnClick() {
        if (selectedObject != null) {
            selectedObject = null;
            return;
        }

        colliders = FindObjectsOfType<BoxCollider2D>();
        var mousePos = GetMousePosition();
        GameObject my_object;

        for (int i = 0; i < colliders.Length; i++) {
            my_object = colliders[i].gameObject;
            Rect rect = new Rect();
            var collider = colliders[i];

            rect.x = collider.bounds.min.x;
            rect.y = collider.bounds.min.y;

            rect.width = collider.bounds.size.x;
            rect.height = collider.bounds.size.y;

            if (rect.Contains(mousePos)) {
                selectedObject = my_object;
                break;
            }
        }
        Debug.Log("Tool click");
    }

    public void Update() {
        if (selectedObject != null) {
            var mousePos = GetMousePosition();
            selectedObject.transform.position = new Vector3(mousePos.x, mousePos.y, selectedObject.transform.position.z);
        }
    }
}
