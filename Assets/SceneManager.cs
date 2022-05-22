using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{

    public GameObject finishScreen;
    public GameObject startScreen;

    // Scene items
    public GameObject player;
    public GameObject platformManager;
    public GameObject staticObjects;
    public GameObject background;
    
    // Prefabs
    public GameObject platformPrefab;
    public GameObject spikePrefab;
    public GameObject exitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static string readLevel(string path)

    {
        try
        {
            StreamReader reader = new StreamReader(path);

            string level = reader.ReadToEnd();

            reader.Close();
            return level;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
    

    public void showEndScreen(bool won)
    {
        player.transform.DetachChildren();
        player.SetActive(false);
        platformManager.SetActive(false);
        staticObjects.SetActive(false);
        background.SetActive(false);
        
        finishScreen.SetActive(true);
        TextMeshProUGUI finishText = finishScreen.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(finishText);
        if (won) {
            finishText.text = "You won";
            finishText.color = Color.green;
        } else {
            finishText.text = "You lost";
            finishText.color = Color.red;
        }
    }

    public void onLoadLevel()
    {
        string levelName = startScreen.GetComponentInChildren<TMP_InputField>().text + ".json";
        string path = Path.Join(Application.persistentDataPath, levelName);

        string json = readLevel(path);

        if (json == null)
        {
            return;
        }

        LevelObject levelObject = JsonUtility.FromJson<LevelObject>(json);
        
       

        foreach (var platform in levelObject.platforms)
        {
            GameObject newPlatform = Instantiate(
                platformPrefab,
                platform.position, Quaternion.identity, platformManager.transform
            );

            newPlatform.GetComponent<SpriteRenderer>().size = platform.size;
            newPlatform.tag = platform.color;
        }
        
        platformManager.GetComponent<PlatformManager>().init();
        
        foreach (var spike in levelObject.spikes)
        {
            Instantiate(spikePrefab, spike.position, Quaternion.identity, staticObjects.transform);
        }

        foreach (var exit in levelObject.exits)
        {
            Instantiate(exitPrefab, exit.position, Quaternion.identity, staticObjects.transform);
        }
        
        player.SetActive(true);
        
        player.transform.position = levelObject.playerStartPosition;

        player.GetComponent<PlayerMovement>().initialPosition = levelObject.playerStartPosition;
        
        player.GetComponent<PlayerMovement>().reset();
        
        background.SetActive(true);
        
        startScreen.SetActive(false);

    }

    public void onRestartGame()
    {
        // finishScreen.SetActive(false);
        //
        // platformManager.SetActive(true);
        // staticObjects.SetActive(true);
        // background.SetActive(true);
        //
        // player.SetActive(true);
        // player.GetComponent<PlayerMovement>().reset();

        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/GameScene");
    }

    
}
