using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWallTool : LevelEditorTool
{
    public GameObject wallPrefab;

    override
    public void Init() {
        Debug.Log("Init Tool Wall");
    }

    override
    public void OnClick() {
        Debug.Log("Tool click");
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);// + Camera.main.transform.position;// + GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        
        Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));
        Debug.Log(GameObject.FindGameObjectsWithTag("Player")[0].transform.position);
        Debug.Log(worldPosition);
        worldPosition.z = 0;

        Instantiate(wallPrefab, worldPosition, Quaternion.identity);
    }
}
