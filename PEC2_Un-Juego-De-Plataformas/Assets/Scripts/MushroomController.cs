using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : EnemyController
{    

    public MushroomController()
    {
        movement = 1f;
    }
    protected override void Move()
    {
        float distance = Mathf.Abs(transform.position.x - playerPosition.transform.position.x);
        
        if (distance < playerRange)
        {
            if (playerPosition.transform.position.x < transform.position.x && enemyIsFacingRight)
            {
                Flip();
            }
            else if (playerPosition.transform.position.x > transform.position.x && !enemyIsFacingRight)
            {
                Flip();
            }            
//            var dir = (playerPosition.position - transform.position).normalized * movementSpeed;
            var test = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
            var dir = (test - transform.position).normalized * movement;
            rigidbody2D.velocity = dir;

        }
    }
        
}
