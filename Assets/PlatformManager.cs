using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Linq;

public class PlatformManager : MonoBehaviour
{
    public string[] colors;
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

    // Update is called once per frame
    void Update()
    {
    }
}
