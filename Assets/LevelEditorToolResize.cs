using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorToolResize : LevelEditorTool
{
    private BoxCollider2D[] colliders;
    GameObject selectedObject;
    SpriteRenderer selectedSpriteRenderer;
    ColliderResize selectedColliderResize;
    Vector3 initialMousePos;
    Vector2 initialSize;
    Vector3 initialPos;
    int quadrant;
    Vector2 centerDir;

    override
    public void Initialize() {
        selectedObject = null;
        selectedSpriteRenderer = null;
        selectedColliderResize = null;
    }

    public void findQuadrant(BoxCollider2D collider) {
        Vector2 center = collider.bounds.center;
        Vector2 mousePos = initialMousePos;
        Vector2 diff = center - mousePos;
        if (diff.x < 0 && diff.y < 0) {
            // The mouse is top right, low left corner is fixed
            // Center moves to top right
            quadrant = 1;
            centerDir = new Vector2(1, 1);
        } else if (diff.x > 0 && diff.y < 0) {
            // The mouse is top left, the low right corner should be fixed
            // The center moves to top left
            quadrant = 2;
            centerDir = new Vector2(-1, 1);
        } else if (diff.x > 0 && diff.y > 0) {
            quadrant = 3;
            centerDir = new Vector2(-1, -1);
        } else if (diff.x < 0 && diff.y > 0) {
            quadrant = 4;
            centerDir = new Vector2(1, -1);
        }
    }

    override
    public void OnClick() {
        if (selectedObject != null) {
            Initialize();
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
                selectedSpriteRenderer = my_object.GetComponent<SpriteRenderer>();
                selectedColliderResize = my_object.GetComponent<ColliderResize>();
                if (selectedSpriteRenderer == null || selectedColliderResize == null) {
                    break;
                }
                selectedObject = my_object;
                initialMousePos = mousePos;
                initialSize = selectedSpriteRenderer.size;
                initialPos = selectedObject.transform.position;
                findQuadrant(collider);
                break;
            }
        }
        Debug.Log("Tool click");
    }

    public void Update() {
        if (selectedObject != null) {
            var mousePos = GetMousePosition();
            Vector2 dist = (mousePos - initialMousePos) * centerDir;
            Debug.Log("Distance = " + dist.x + " " + dist.y);
            selectedSpriteRenderer.size = initialSize + dist;
            selectedSpriteRenderer.size = new Vector2(Mathf.Abs(selectedSpriteRenderer.size.x), 
                                                  Mathf.Abs(selectedSpriteRenderer.size.y));
            
            selectedColliderResize.Start();

            Vector3 newPos = initialPos;
            newPos += (Vector3) (centerDir * dist / 2);
            Debug.Log("Move with " + (Vector3) (centerDir * dist / 2));

            selectedObject.transform.position = newPos;
        }
    }
}
