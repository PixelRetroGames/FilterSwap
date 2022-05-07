using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Filter : MonoBehaviour
{
    public float changeDelay;

    PlatformManager pm;
    int color = 1;
    float changeDelayRemaining = 0;

    // Start is called before the first frame update
    void Start()
    {
        pm = FindObjectsOfType<PlatformManager>()[0].GetComponent<PlatformManager>();
    }

    void SetPlatformsOfColorActive(int colorIndex, bool active) {
        Debug.Log("Color " + pm.colors[colorIndex] + " " + active);
        for (int i = 0; i < pm.platformsOfColor[colorIndex].Count; i++) {
            pm.platformsOfColor[colorIndex][i].SetActive(active);
        }
    }

    void ApplyFilter() {
        // Set inactive colors
        for (int i = 0; i < color; i++) {
           SetPlatformsOfColorActive(i, false);
        }

        for (int i = color + 1; i < pm.colors.Length; i++) {
           SetPlatformsOfColorActive(i, false);
        }

        // Set Active Color
        SetPlatformsOfColorActive(color, true);
    }

    // Update is called once per frame
    void Update()
    {
        changeDelayRemaining = Math.Max(0, changeDelayRemaining - Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl)) {
            if (changeDelayRemaining == 0) {
                color = (color + 1) % pm.colors.Length;
                changeDelayRemaining = changeDelay;
                ApplyFilter();
                Debug.Log("Filter changed in" + pm.colors[color]);
            }
        }
    }
}
