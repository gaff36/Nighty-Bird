using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjects : MonoBehaviour
{
    private Rigidbody2D rb;
    
    
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        rb.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
        if (GameControl.instance.gameOver == true)
        {
            rb.velocity = Vector2.zero;
        }

        
    }
}
