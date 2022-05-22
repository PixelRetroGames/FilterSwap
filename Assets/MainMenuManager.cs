using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void onSelectLevelClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/GameScene");
    }
    
    public void onCreateLevelClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void onQuitGameClick()
    {
        Application.Quit();
    }
}
