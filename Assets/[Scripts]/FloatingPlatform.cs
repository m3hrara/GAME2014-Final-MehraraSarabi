/*
FloatingPlatform.cs
Author: Mehrara Sarabi 
Student ID: 101247463
Last modified: 2021-12-14
Description: This program contains the behaviour of the floating platform. Including floating up and down effect, shrinking on player contact,
resetting the size when player is gone, and playing sfx on shrink and resize.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    public SFXManager sfx;
    private float localX;
    public float maxY;
    public float minY;
    private bool playerOnPlatform = false;
    private bool goUp = true;

    // Start is called before the first frame update
    void Start()
    {
        maxY = transform.position.y + 0.5f;
        minY = transform.position.y - 0.5f;
        localX = transform.localScale.x;
        sfx = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // platform slightly moves up and down when player is NOT on it
        if(!playerOnPlatform)
        {
            // go up if its higher than the mid pos
            if (goUp)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.01f, this.transform.position.z);
                if (this.transform.position.y >= maxY)
                {
                    goUp = false;
                }
            }
            else if (!goUp)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.01f, this.transform.position.z);
                if (this.transform.position.y <= minY)
                {
                    goUp = true;
                }
            }
            // go back to original size if it's been shrunk
            if(transform.localScale.x<localX)
            {
                this.transform.localScale = new Vector3(this.transform.localScale.x + 0.005f, this.transform.localScale.y, this.transform.localScale.z);
            }
        }
        // start shrinking when player is on platform
        else if(playerOnPlatform)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x - 0.005f, this.transform.localScale.y, this.transform.localScale.z);
            if(transform.localScale.x<=0.02f)
            {
                this.transform.localScale = new Vector3(0, this.transform.localScale.y, this.transform.localScale.z);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            playerOnPlatform = true;
            sfx.PlayShrink();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerOnPlatform = false;
            sfx.PlayResize();
        }
    }
}
