using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    public float maxY;
    public float minY;
    private bool playerOnPlatform = false;
    private bool goUp = true;
    // Start is called before the first frame update
    void Start()
    {
        maxY = transform.position.y + 0.5f;
        minY = transform.position.y - 0.5f;
    }

    // Update is called once per frame
    void Update()
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
        }
        // start shrinking when player is on platform
        else if(playerOnPlatform)
        {

        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floating")
        {
            playerOnPlatform = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floating")
        {
            playerOnPlatform = false;
        }
    }
}
