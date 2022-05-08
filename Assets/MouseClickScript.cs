using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickScript : MonoBehaviour
{
    public Rect invalidArea;
    public LevelEditor levelEditor;

    private bool isValid(Vector3 pos) {
        return !(pos.x >= invalidArea.x && pos.x <= invalidArea.x + invalidArea.width 
              && pos.y >= invalidArea.y && pos.y <= invalidArea.y + invalidArea.height);
    }  

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        if (!isValid(mousePos)) {
            return;
        }

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log(mousePos);
            levelEditor.OnClick();
        }
    }
}
