using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Filter : MonoBehaviour
{
    public float changeDelay;
    public float alpha;
    public float platformAlphaActive;
    public float platformAlphaInactive;

    SpriteRenderer sprite;
    PlatformManager pm;
    int color = 1;
    float changeDelayRemaining = 0;

    // Start is called before the first frame update
    public void Start()
    {
        pm = FindObjectsOfType<PlatformManager>()[0].GetComponent<PlatformManager>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        transform.localScale = new Vector2(width, height);
        Debug.Log(width + " " + height);
        SetFilterSpriteColor();
    }

    void SetFilterSpriteColor() {
        Color c = pm.GetColor(pm.colors[color]);
        c.a = alpha;
        sprite.color = c;
    }

    void SetPlatformsOfColorActive(int colorIndex, bool active) {
        Debug.Log("Color " + pm.colors[colorIndex] + " " + active);
        for (int i = 0; i < pm.platformsOfColor[colorIndex].Count; i++) {
            SpriteRenderer sr = pm.platformsOfColor[colorIndex][i].GetComponentInChildren<SpriteRenderer>();
            pm.platformsOfColor[colorIndex][i].GetComponentInChildren<BoxCollider2D>().enabled = active;
            Color newColor = sr.color;
            if (active) {
                newColor.a = platformAlphaActive;
                sr.gameObject.transform.position = sr.gameObject.transform.position - sr.gameObject.transform.position.z * new Vector3(0, 0, 1) - (4 * new Vector3(0, 0, 1));
            } else {
                newColor.a = platformAlphaInactive;
                sr.gameObject.transform.position = sr.gameObject.transform.position - sr.gameObject.transform.position.z * new Vector3(0, 0, 1);
            }
            sr.color = newColor;
        }
    }

    void ApplyFilter() {
        // Set inactive colors
        for (int i = 0; i < color; i++) {
           SetPlatformsOfColorActive(i, true);
        }

        for (int i = color + 1; i < pm.colors.Length; i++) {
           SetPlatformsOfColorActive(i, true);
        }

        // Set Active Color
        SetPlatformsOfColorActive(color, false);

        SetFilterSpriteColor();
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
