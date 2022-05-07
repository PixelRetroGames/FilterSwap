using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        spriteRenderer.color = FindObjectsOfType<PlatformManager>()[0].GetComponent<PlatformManager>().GetColor(transform.parent.tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
