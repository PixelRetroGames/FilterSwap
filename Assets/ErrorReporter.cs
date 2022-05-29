using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorReporter : MonoBehaviour
{

    public float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI  text = GetComponent<TextMeshProUGUI>();
        if (text.color.a > 0)
        {
            text.color = new Color(
                    text.color.r,
                    text.color.g,
                    text.color.b, 
                    text.color.a - fadeSpeed * Time.deltaTime
                );

            text.faceColor = new Color32(
                text.faceColor.r,
                text.faceColor.g,
                text.faceColor.b,
                (byte) Mathf.Clamp(text.color.a, 0, 255)
            );
        }
    }

    public void reportError(string message)
    {
        TMP_Text text = GetComponent<TMP_Text>();
        text.text = message;
        text.alpha = 0xFF;
    }
}
