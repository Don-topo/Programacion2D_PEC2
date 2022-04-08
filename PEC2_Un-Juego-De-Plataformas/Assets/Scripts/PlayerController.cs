using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 20.0f;
    private float movement = 0.0f;
    private bool grounded = true;

    private new Rigidbody2D rigidbody;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        movement = Input.GetAxisRaw("Horizontal") * movementSpeed;
        Vector3 targetVelocity = new Vector2(movement * 10f, rigidbody.velocity.y);
        Vector3 test = Vector3.zero;
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref test, .05f);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            // Jump
            grounded = false;
            rigidbody.AddForce(new Vector2(0.0f, 400.0f));
           // animator.SetBool("", false);
            animator.SetTrigger("Jumping");
        }
        // Attack

        // Roll

    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<BoxCollider2D>();
       
    }

    private void flipPlayer()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            grounded = true;
            animator.SetTrigger("");
        }
    }
}
