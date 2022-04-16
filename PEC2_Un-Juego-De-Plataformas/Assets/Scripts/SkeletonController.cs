using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : EnemyController
{
    protected override void Attack()
    {
        base.Attack();
    }

    protected override void Move()
    {
        float distance = Mathf.Abs(transform.position.x - playerPosition.transform.position.x);
        if (distance < playerRange)
        {
            if(playerPosition.transform.position.x < transform.position.x && enemyIsFacingRight)
            {
                Flip();
            }
            else if(playerPosition.transform.position.x > transform.position.x && !enemyIsFacingRight)
            {
                Flip();
            }
        }
    }
}
