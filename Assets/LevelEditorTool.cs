using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public abstract class LevelEditorTool : MonoBehaviour
{
    public string buttonText;

    protected Button button;
    protected TextMeshProUGUI textMesh;

    [System.NonSerialized]
    protected PlatformManager platformManager;
    protected LevelEditor LevelEditor;

    public void SetLinks(PlatformManager platformManager, LevelEditor LevelEditor) {
        this.platformManager = platformManager;
        this.LevelEditor = LevelEditor;
    }

    public void OnSelect() {
        LevelEditor.selectedTool = this;
    }

    public void Init() {
        button = GetComponent<Button>();
        textMesh = button.GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = buttonText;
    }

    public Vector3 GetMousePosition() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        worldPosition.z = 0;
        return worldPosition;
    }

    public abstract void Initialize();
    public abstract void OnClick();
}
