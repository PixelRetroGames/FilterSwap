using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEditorToolSave : MonoBehaviour
{

    public void Start()
    {
    }

    public void Update()
    {

    }
    
    public static void writeLevel(string path, string json)
    {
        StreamWriter writer = new StreamWriter(path, false);

        writer.Write(json);

        writer.Close();
        
    }

    

    public void saveLevel()
    {
        
        LevelObject toSave = new LevelObject();
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        toSave.playerStartPosition = player.transform.position;

        
        
        GameObject[] spikes = GameObject.FindGameObjectsWithTag("Spike");
        GameObject[] exits = GameObject.FindGameObjectsWithTag("Finish");

        
        
        PlatformManager platformManager = GameObject.FindWithTag("PlatformManager").GetComponent<PlatformManager>();

        foreach (var color in platformManager.colors)
        {
            var platformsOfColor = GameObject.FindGameObjectsWithTag(color);
            
            foreach (var platform in platformsOfColor)
            {
                var information = new PlatformInformation(
                    platform.transform.position,
                    platform.GetComponent<SpriteRenderer>().size,
                    color);
                toSave.platforms.Add(information);
            }
        }

        var platformsOfNoColor = GameObject.FindGameObjectsWithTag("Uncolored");

        foreach (var platform in platformsOfNoColor)
        {
            var information = new PlatformInformation(
                platform.transform.position,
                platform.GetComponent<SpriteRenderer>().size,
                "Uncolored");
            toSave.platforms.Add(information);
        }

        foreach (var spike in spikes)
        {
            var information = new SpikeInformation(spike.transform.position);
            toSave.spikes.Add(information);
        }


        foreach (var exit in exits)
        {
            var information = new ExitInformation(exit.transform.position);
            toSave.exits.Add(information);
        }


        String json = JsonUtility.ToJson(toSave);
        
        
        string levelName = GetComponentInChildren<TMP_InputField>().text + ".json";

        string path = Path.Join(Application.persistentDataPath , levelName);
        
        Debug.Log(path);
        
        writeLevel(path, json);

        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/MenuScene");
    }
}
