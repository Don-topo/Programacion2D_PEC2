using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 20.0f;
    public Transform groundTransform;
    public float jumpForce = 20.0f;

    private float movement = 0.0f;
    private bool grounded = true;
    private new Rigidbody2D rigidbody;
    private Animator animator;
    private bool playerIsFacingRight = true;
    private bool interactWithChest = false;

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
        Vector3 targetVelocity = new Vector2(movement * 0.2f, rigidbody.velocity.y);
        Vector3 test = Vector3.zero;
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref test, .05f);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            // Jump
            // rigidbody.AddForce(new Vector2(0.0f, 400.0f));
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if(movement > 0.01f && !playerIsFacingRight)
        {
            FlipPlayer();
        }
        else if (movement < -0.01f && playerIsFacingRight)
        {
            FlipPlayer();
        }

        CheckMovement();

        if (Input.GetMouseButtonDown(0) && grounded)
        {
            // Attack
            animator.SetTrigger("Attack");
        }

        if(Input.GetMouseButtonDown(1) && grounded)
        {
            // Roll
            animator.SetTrigger("Dash");
        }
            // add facing dash movement


    }

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    private void FlipPlayer()
    {
        playerIsFacingRight = !playerIsFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void CheckMovement()
    {
        if (movement != 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    private void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundTransform.position, Vector2.down);
        float distance = Mathf.Abs(groundTransform.position.y - hit.point.y);

        if (hit.collider != null)
        {
            if (distance == 0f && hit.collider.gameObject.CompareTag("Floor"))
            {
                grounded = true;
                animator.SetBool("Jumping", false);
            }
            else
            {
                grounded = false;
                animator.SetBool("Jumping", true);
            }
        }              
    }


}
