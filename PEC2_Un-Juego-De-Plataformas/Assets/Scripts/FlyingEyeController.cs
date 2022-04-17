using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeController : EnemyController
{   
    public FlyingEyeController()
    {
        healtPoints = 3;
        attackRange = 5f;
        damage = 1;
        playerRange = 10f;
        movement = 1.5f;
        attackSpeed = 2f;
    }

    protected override void Attack()
    {
        //base.Attack();
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
            var test = new Vector3(playerPosition.position.x, transform.position.y, transform.position.z);
            var dir = (test - transform.position).normalized * movement;
            rigidbody2D.velocity = dir;
        }        
    }

}
