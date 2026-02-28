using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    public bool well;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        well = true;
    }

    // Update is called once per frame
    void Update()
    {
        ResetTriggers();
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
            anim.SetBool("w_up", true);
            
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);
            if (well) { anim.SetBool("ww_down", true); }
            else { anim.SetBool("uw_down", true); }
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
            if (well) { anim.SetBool("ww_left", true); }
            else { anim.SetBool("uw_left", true); }
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);
            if (well) { anim.SetBool("ww_right", true); }
            else { anim.SetBool("uw_right", true); }
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
