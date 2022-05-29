using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    //[SerializeField]
    private LevelEditorTool[] tools;

    public LevelEditorTool selectedTool;
    public ErrorReporter errorReporter;
    private PlatformManager platformManager;

    // Start is called before the first frame update
    public void Start()
    {
        platformManager = FindObjectsOfType<PlatformManager>()[0].GetComponent<PlatformManager>();
        tools = GetComponentsInChildren<LevelEditorTool>();
        foreach (var tool in tools) {
            tool.SetLinks(platformManager, this);
            tool.Init();
        }
    }

    public void OnClick() 
    {
        if (selectedTool == null)
        {
            errorReporter.reportError("No tool selected!");
        }
        else
        {

            selectedTool.OnClick();
        }

        platformManager.Start();
    }
}
