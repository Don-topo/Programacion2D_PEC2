using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    protected int healtPoints = 2;
    protected int damage = 1;
    private Animator animator;
    private Collider2D[] colliders2D;
    private AudioSource audioSource;
    protected new Rigidbody2D rigidbody2D;
    protected bool enemyIsFacingRight = true;
    protected float movement = 0;
    protected bool canMove = true;
    public Transform attackZone;
    public float attackRange = 5.0f;
    public float playerRange = 20f;
    public LayerMask attackLayer;
    public Transform playerPosition;

    // Start is called before the first frame update
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        colliders2D = gameObject.GetComponents<Collider2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healtPoints > 0)
        {
            Move();
        }        
    }

    public void GetHit(int damage)
    {
        animator.SetTrigger("Hit");
        canMove = false;
        StartCoroutine(WaitHit());
        healtPoints -= damage;
        if(healtPoints <= 0)
        {
            Death();
        }
    }

    protected void Death()
    {
        animator.SetTrigger("Death");
        rigidbody2D.isKinematic = true;
        foreach(Collider2D cl in colliders2D)
        {
            cl.enabled = false;
        }        
    }

    protected virtual void Move() { }

    protected virtual void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackZone.position, attackRange, attackLayer);
        foreach (Collider2D cl in hitObjects)
        {
            if (cl.gameObject.CompareTag("Player"))
            {
                cl.GetComponent<PlayerController>().GetHit(damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().GetHit(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackZone == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackZone.position, attackRange);
    }

    protected void Flip()
    {
        enemyIsFacingRight = !enemyIsFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    IEnumerator WaitHit()
    {
        canMove = true;
        yield return new WaitForSeconds(1f);
    } 

}
