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
                var selectedSpriteRenderer = my_object.GetComponent<SpriteRenderer>();
                var selectedColliderResize = my_object.GetComponent<ColliderResize>();
                if (selectedSpriteRenderer == null || selectedColliderResize == null) {
                    break;
                }
                selectedObject = my_object;
                
                OnRotate();
                break;
            }
        }
    }

    public void OnRotate() {
        var objectPosition = selectedObject.transform.position;
        
        objectPosition.z = transform.position.z  + (float) 3.6;
        objectPosition.x = transform.position.x;
        objectPosition.y = transform.position.y;
       
        var clone = selectedObject;
   
   
        clone = Instantiate(prefab,  objectPosition, transform.rotation);
   
   
        var objectRotation = transform.rotation;
        print(objectRotation.eulerAngles.y);
 
        clone.transform.RotateAround(transform.position,Vector3.up,objectRotation.eulerAngles.y);

        selectedObject = clone;
        Debug.Log("Rotated!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}