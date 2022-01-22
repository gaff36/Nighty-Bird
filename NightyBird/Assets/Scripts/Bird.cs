using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float force = 200f;
    private bool isDead = false;
    public bool goingRight = true;
    private bool done = true;
    private float t;

    public Animator animator;
    private Rigidbody2D rb;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        t = System.DateTime.Now.Second;

    }

    
    void Update()
    {      

        if(GameControl.instance.isStarted == false)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;

            if (rb.position.x >= -0.05f)
            {
                goingRight = false;
            }
            if (rb.position.x < -1.73f)
            {
                goingRight = true;
            }
            if (goingRight && (done || (System.DateTime.Now.Second - t) % 3 == 0))
            {
                t = System.DateTime.Now.Second;                
                done = false;
                if(rb.velocity.y > 0f)
                {
                    rb.velocity = Vector2.zero;
                    rb.velocity = new Vector2(0.15f, Random.Range(-0.15f, 0f));
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    rb.velocity = new Vector2(0.15f, Random.Range(0f, 0.15f));
                }
            }
            if (!goingRight && (!done || (System.DateTime.Now.Second - t) % 3 == 0))
            {
                t = System.DateTime.Now.Second;
                done = true;
                if (rb.velocity.y > 0f)
                {
                    rb.velocity = Vector2.zero;
                    rb.velocity = new Vector2(-0.15f, Random.Range(-0.15f, 0f));
                }
                else
                {
                    rb.velocity = Vector2.zero;
                    rb.velocity = new Vector2(-0.15f, Random.Range(0f, 0.15f));
                }
            }
            

            
            
            
        }

        if (GameControl.instance.isStarted == true)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;

            if (isDead == false)
            {

                foreach (Touch touch in Input.touches)
                {                   
                    if (touch.phase == TouchPhase.Began && touch.position.x == Input.GetTouch(0).position.x && touch.position.y == Input.GetTouch(0).position.y)
                    {                   
                            GameControl.instance.playSwingSound();
                            rb.velocity = Vector2.zero;
                            rb.AddForce(new Vector2(0, force));                      
                    }        
                    
                }
            

                if (rb.velocity.y > 0)
                {                    
                    Quaternion rotation;
                    rotation = Quaternion.AngleAxis(30, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 15 * Time.deltaTime);

                }

                if (rb.velocity.y < 0)
                {
                    Quaternion rotation;
                    rotation = Quaternion.AngleAxis(-30, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 15 * Time.deltaTime);

                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Ground") == true || other.gameObject.tag.Equals("Column") == true)
        {
            rb.velocity = Vector2.zero;
            isDead = true;
            animator.SetBool("isDead", true);
            GameControl.instance.BirdDied();
            Quaternion rotation;
            rotation = Quaternion.AngleAxis(180, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 50 * Time.deltaTime);
            rb.AddForce(new Vector2(0, -100f));
        }        
    }

    public void stopBird()
    {
        rb.velocity = Vector2.zero;
    }
}
