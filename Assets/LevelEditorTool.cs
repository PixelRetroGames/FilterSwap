using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelEditorTool : MonoBehaviour
{
    private PlatformManager platformManager;
    private LevelEditor LevelEditor;

    public void SetLinks(PlatformManager platformManager, LevelEditor LevelEditor) {
        this.platformManager = platformManager;
        this.LevelEditor = LevelEditor;
    }

    public void OnSelect() {
        LevelEditor.selectedTool = this;
    }

    public abstract void Init();
    public abstract void OnClick();
}
