using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderResize : MonoBehaviour
{
    private BoxCollider2D platformCollider;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        platformCollider = gameObject.GetComponent<BoxCollider2D>();
        platformCollider.size = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y);
    }
}