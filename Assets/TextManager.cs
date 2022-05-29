using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

public class TextManager : MonoBehaviour
{
    public TMP_Text CurrBaseText, PrevPrevBaseText, PrevBaseText, NextBaseText, NextNextBaseText;
    public TMP_Text CurrCustomText, PrevPrevCustomText, PrevCustomText, NextCustomText, NextNextCustomText;
    public GameObject startScreen;

    List <string> baseFileEntries;
    List <string> customFileEntries;
    int baseindex, customindex;

    // Start is called before the first frame update
    void Start()
    {
        ResetBaseEntries();
        ResetCustomEntries();
    }

    void ResetBaseEntries() {
        baseindex = 0;
        baseFileEntries = new List<string>();
        UpdateBaseEntries();      
    }   

    void ResetCustomEntries() {
        customindex = 0;
        customFileEntries = new List<string>();
        UpdateCustomEntries();
    }

    void UpdateBaseEntries() {
        string worldsFolder = Application.persistentDataPath;
        DirectoryInfo d = new DirectoryInfo(worldsFolder);

        foreach (var file in d.GetFiles("base_*")){
            Debug.Log(file);

            string aux = file.FullName;
            int poz = -1;

            while (aux.IndexOf("\\", poz + 1) != -1) {
                poz = aux.IndexOf("\\", poz + 1);
            }

            // Remove path
            aux = aux.Remove(0, poz + 1);

            // Remove base_
            aux = aux.Remove(0, 5);

            // Remove .json
            aux = aux.Remove(aux.Length - 5, 5);

            baseFileEntries.Add(aux);
        }
    }

    void UpdateCustomEntries() {
        string worldsFolder = Application.persistentDataPath;
        DirectoryInfo d = new DirectoryInfo(worldsFolder);

        foreach (var file in d.GetFiles("custom_*")){
            Debug.Log(file);

            string aux = file.FullName;
            int poz = -1;

            while (aux.IndexOf("\\", poz + 1) != -1) {
                poz = aux.IndexOf("\\", poz + 1);
            }

            // Remove path
            aux = aux.Remove(0, poz + 1);

            // Remove custom_
            aux = aux.Remove(0, 7);

            // Remove .json
            aux = aux.Remove(aux.Length - 5, 5);

            customFileEntries.Add(aux);
        }
    }

    public string getBaseLevelName(int idx) {
        if (idx < 0 || idx >= baseFileEntries.Count) {
            return "";
        } else {
            return baseFileEntries[idx];
        }
    }

    public string getCustomLevelName(int idx) {
        if (idx < 0 || idx >= customFileEntries.Count) {
            return "";
        } else {
            return customFileEntries[idx];
        }
    }

    public void onBaseSelect() {
        startScreen.GetComponentInChildren<TMP_InputField>().text = "base_" + getBaseLevelName(baseindex);
    }

    public void onCustomSelect() {
        startScreen.GetComponentInChildren<TMP_InputField>().text = "custom_" + getCustomLevelName(customindex);
    }

    public void onBaseUp() {
        if (baseindex > 0) {
            --baseindex;
        }
    
    }

    public void onBaseDown() {
        if (baseindex + 1 < baseFileEntries.Count) {
            ++baseindex;
        }
    }

    public void onCustomUp() {
        if (customindex > 0) {
            --customindex;
        }
    
    }

    public void onCustomDown() {
        if (customindex + 1 < customFileEntries.Count) {
            ++customindex;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PrevPrevBaseText.text = getBaseLevelName(baseindex - 2);
        PrevBaseText.text = getBaseLevelName(baseindex - 1);
        CurrBaseText.text = getBaseLevelName(baseindex);
        NextBaseText.text = getBaseLevelName(baseindex + 1);
        NextNextBaseText.text = getBaseLevelName(baseindex + 2);

        PrevPrevCustomText.text = getCustomLevelName(customindex - 2);
        PrevCustomText.text = getCustomLevelName(customindex - 1);
        CurrCustomText.text = getCustomLevelName(customindex);
        NextCustomText.text = getCustomLevelName(customindex + 1);
        NextNextCustomText.text = getCustomLevelName(customindex + 2);
    }
}
