using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject potion;

    private AudioSource audioSource;
    private Animator animator;
    private BoxCollider2D[] colliders;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        colliders = GetComponents<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // TODO Play sound
            audioSource.Play();
            foreach(BoxCollider2D bx in colliders)
            {
                bx.enabled = false;
            }
            // TODO Play animation
            animator.SetTrigger("break");
            // TODO Spawn potion
            GameObject newObject =  Instantiate(potion, transform.position, Quaternion.identity, null);
            
            // TODO Destroy object
            //Destroy(gameObject);
        }
    }
}
