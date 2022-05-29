using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorToolRotateSpikes : LevelEditorTool
{
    private BoxCollider2D[] colliders;
    public GameObject prefab;
    private GameObject selectedObject;

    override
    public void Initialize() {

    }

    override
    public void OnClick() {
        Debug.Log("Rotate click");
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
                OnRotate(i);
                my_object = selectedObject;
                break;
            }
        }
    }

    public void OnRotate(int idx) {

        var currentRotation = selectedObject.transform.eulerAngles;
        currentRotation.z = (currentRotation.z + 90);
        selectedObject.transform.eulerAngles = currentRotation;

        Debug.Log("Rotated!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}