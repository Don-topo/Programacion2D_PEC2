using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 20.0f;
    public Transform groundTransform;
    public float jumpForce = 20.0f;
    public Transform attackZone;
    public float attackRange = 5.0f;
    [SerializeField]
    public LayerMask attackLayer;
    [SerializeField]
    LayerMask floorMask;
    public float attackVelocity = 2f;

    private float movement = 0.0f;
    private bool grounded = true;
    private new Rigidbody2D rigidbody;
    private Animator animator;
    private bool playerIsFacingRight = true;
    private float nextAttackTime = 0f;

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
        
        if(Input.GetMouseButtonDown(1) && grounded)
        {
            // Roll
            animator.SetTrigger("Dash");
            // add facing dash movement
        }

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0) && grounded)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRange;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }


    }

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    void OnDrawGizmosSelected()
    {
        if(attackZone == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackZone.position, attackRange);
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackZone.position, attackRange, attackLayer);
        foreach (Collider2D cl in hitObjects)
        {
            switch (cl.gameObject.tag)
            {
                case "Box":
                    cl.GetComponent<BoxController>().PlayerInteract();
                    break;
            }
        }
    }

    private void Interact()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackZone.position, attackRange, attackLayer);
        foreach (Collider2D cl in hitObjects)
        {
            if (cl.gameObject.CompareTag("Chest"))
            {
                cl.GetComponent<SpawnCoins>().Spawn();
            }
        }
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
        RaycastHit2D hit = Physics2D.Raycast(groundTransform.position, Vector2.down, 0.25f, floorMask);

        if (hit == true)
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
