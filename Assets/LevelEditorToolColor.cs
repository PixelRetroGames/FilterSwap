using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorToolColor : LevelEditorTool
{
    private BoxCollider2D[] colliders;

    override
    public void Initialize() {
    }

    private int findColor(string color) {
        for (int i = 0; i < platformManager.colors.Length; i++) {
            if (color == platformManager.colors[i]) {
                return i;
            }
        }
        return 2;
    }

    private string getNextColor(string color) {
        if (findColor(color) == 2) {
            return platformManager.colors[0];
        } 

        if (findColor(color) == 1) {
            return "Default";
        }

        return platformManager.colors[(findColor(color) + 1) % platformManager.colors.Length];
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
                Debug.Log("Changed color from " + my_object.tag);
                my_object.tag = getNextColor(my_object.tag);
                if (my_object.GetComponent<PlatformColor>() == null) {
                    break;
                }
                my_object.GetComponent<PlatformColor>().Start();
                Debug.Log("to " + my_object.tag);
                break;
            }
        }
        Debug.Log("Tool click");
    }
}
