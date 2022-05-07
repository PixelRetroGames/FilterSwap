using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using static PlayerMovement.States;

[System.Serializable]   
public class StateSpriteInfo {
    public string name;
    public int startPos;
    public int nrSprites;

    public StateSpriteInfo(string name, int startPos, int nrSprites) {
        this.name = name;
        this.startPos = startPos;
        this.nrSprites = nrSprites;
    }
};

public class PlayerMovement : MonoBehaviour {
    public Sprite[] spriteArray;
    private StateSpriteInfo[] stateSprite = new StateSpriteInfo[] {
        new StateSpriteInfo("idle", 0, 2),
        new StateSpriteInfo("jump", 2, 2),
        new StateSpriteInfo("fall", 4, 1),
        new StateSpriteInfo("run", 5, 4)
    };

    public float speed;
    public float jump;
    float moveVelocity;
    Vector2 lastPos;

    public enum States {
        STATE_IDLE = 0,
        STATE_JUMP = 1,
        STATE_FALL = 2,
        STATE_MOVE = 3
    };

    private States state = STATE_IDLE;
    private float stateChangeDelayRemaining = 0;
    public float stateChangeDelay;

    private int animationFrame = 0;
    private float animationFrameChangeDelayRemaining = 0;
    public float animationFrameChangeDelay;

    private SpriteRenderer spriteRenderer;

    //Grounded Vars
    bool grounded = false;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() 
    {
        //Jumping
        if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.W)) 
        {
            if(grounded)
            {
                GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }

        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) 
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) 
        {
            moveVelocity = speed;
        }

        GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
        
        stateChangeDelayRemaining = Math.Max(0, stateChangeDelayRemaining - Time.deltaTime);

        Vector2 pos = GetComponent<Rigidbody2D>().position;
        const double alpha = 0.0001;

        if (stateChangeDelayRemaining == 0) {
            States lastState = state;
            if (Math.Abs(pos.x - lastPos.x) < alpha && Math.Abs(pos.y - lastPos.y) < alpha && grounded) {
                state = STATE_IDLE;
            } else if (pos.y > lastPos.y) {
                state = STATE_JUMP;
            } else if (pos.y < lastPos.y) {
                state = STATE_FALL;
            } else {
                state = STATE_MOVE;
            }

            if (pos.x < lastPos.x) {
                spriteRenderer.flipX = true;
            } else if (pos.x > lastPos.x){
                spriteRenderer.flipX = false;
            }

            stateChangeDelayRemaining = stateChangeDelay;
            if (state != lastState) {
                animationFrame = 0;
                spriteRenderer.sprite = spriteArray[stateSprite[(int) state].startPos];
            }
            
            lastPos = pos;
        }

        animationFrameChangeDelayRemaining = Math.Max(0, animationFrameChangeDelayRemaining - Time.deltaTime);

        if (animationFrameChangeDelayRemaining == 0) {
            animationFrameChangeDelayRemaining = animationFrameChangeDelay;
            animationFrame = (animationFrame + 1) % stateSprite[(int) state].nrSprites;
            
            spriteRenderer.sprite = spriteArray[stateSprite[(int) state].startPos + animationFrame];
        }
    }

    //Check if Grounded
    void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        Debug.Log("Grounded" + grounded);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
        Debug.Log("Grounded" + grounded);
    }
}