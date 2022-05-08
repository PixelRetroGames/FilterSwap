using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    [SerializeField]
    public LevelEditorTool[] tools;

    public LevelEditorTool selectedTool;

    // Start is called before the first frame update
    void Start()
    {
        PlatformManager platformManager = FindObjectsOfType<PlatformManager>()[0].GetComponent<PlatformManager>();
        foreach (var tool in tools) {
            tool.SetLinks(platformManager, this);
            tool.Init();
        }
    }

    public void OnClick() 
    {
        selectedTool.OnClick();
    }
}
