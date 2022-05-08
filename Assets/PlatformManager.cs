using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Linq;

public class PlatformManager : MonoBehaviour
{
    public string[] colors;
    public Color[] colorsValues;
    public List<GameObject>[] platformsOfColor;

    // Start is called before the first frame update
    void Start()
    {
        platformsOfColor = new List<GameObject>[colors.Length];
        for (int i = 0; i < colors.Length; i++)
        {
            platformsOfColor[i] = GameObject.FindGameObjectsWithTag(colors[i]).ToList();
        }
    }

    public Color GetColor(string colorName) {
        Debug.Log(colorName);
        for (int i = 0; i < colors.Length; i++) {
            if (colors[i].Equals(colorName)) {
                Debug.Log("color found" + colorsValues[i]);
                return colorsValues[i];
            }
        }
        Debug.Log("color not found");
        return Color.white;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
