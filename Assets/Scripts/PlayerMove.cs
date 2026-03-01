using System;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Movement & physics
    public float speed;
    private Rigidbody2D rb;
    int direction;
    private int inactiveDirection;
    private Vector2[] directions = new Vector2[4];

    // Animations
    private Animator anim;
    public bool well;

    // Special mechanics
    static int mirrorLayerMask;
    private bool touchingLamp;
    private bool inTheDark;
    private GameObject lamp;
    private int keys;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        well = true;
        direction = 1;
        inactiveDirection = -1;
        directions[0] = Vector2.up;
        directions[1] = Vector2.down;
        directions[2] = Vector2.left;
        directions[3] = Vector2.right;
        mirrorLayerMask = LayerMask.GetMask("Mirror");
        touchingLamp = false;
        inTheDark = false;
        keys = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Regular walk controller
        ResetTriggers();
        if (Input.GetKey(KeyCode.W) && inactiveDirection != 0)
        {
            rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
            direction = 0;
            anim.SetBool("w_up", true);
        } 
        else if (Input.GetKey(KeyCode.S) && inactiveDirection != 1)
        {
            rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);
            direction = 1;
            if (well) { anim.SetBool("ww_down", true); }
            else { anim.SetBool("uw_down", true); }
        } 
        else if (Input.GetKey(KeyCode.A) && inactiveDirection != 2)
        {
            rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
            direction = 2;
            if (well) { anim.SetBool("ww_left", true); }
            else { anim.SetBool("uw_left", true); }
        } 
        else if (Input.GetKey(KeyCode.D) && inactiveDirection != 3)
        {
            rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
            direction = 3;
            if (well) { anim.SetBool("ww_right", true); }
            else { anim.SetBool("uw_right", true); }
        }

        // Checks for mirror collisions
        RaycastHit2D mirrorHit = Physics2D.Raycast(transform.position - new Vector3(0, 1, 0), directions[direction], 500, mirrorLayerMask); 
        Debug.DrawLine(transform.position, transform.position + (Vector3)(directions[direction] * 500));             
        if (mirrorHit && !inTheDark)
        { 
            Debug.Log("Mirror hit");
            inactiveDirection = direction;
        }

        // Checks if player is toggling light switch
        if (touchingLamp)
        {
            if (Input.GetKey(KeyCode.F))
            {
                Debug.Log("Switched lamp off");
                LampScript ls = lamp.GetComponent<LampScript>();
                ls.SwitchSprite();
                if (!ls.on)
                {
                    inactiveDirection = -1;
                    inTheDark = true;
                }
                else
                {
                    inTheDark = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Key"))
        {
            collider.gameObject.SetActive(false);
            keys++;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lamp"))
        {
            lamp = collision.gameObject;
            touchingLamp = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lamp"))
        {
            touchingLamp = false;
        }
    }

    void ResetTriggers()
    {
        anim.SetBool("w_up", false);
        anim.SetBool("ww_down", false);
        anim.SetBool("uw_down", false);
        anim.SetBool("ww_left", false);
        anim.SetBool("uw_left", false);
        anim.SetBool("ww_right", false);
        anim.SetBool("uw_right", false);
    }
}
