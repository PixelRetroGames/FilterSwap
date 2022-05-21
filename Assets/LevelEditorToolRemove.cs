using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorToolRemove : LevelEditorTool
{
    private BoxCollider2D[] colliders;

    override
    public void Initialize() {

    }

    override
    public void OnClick() {
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
                Destroy(my_object);
                colliders = FindObjectsOfType<BoxCollider2D>();
            }
        }
        Debug.Log("Tool click");
    }
}
