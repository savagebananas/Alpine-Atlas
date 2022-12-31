using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : State
{
    public Enemy enemy;

    private GameObject player;
    private float speed;
    private float attackRange;

    public State attackState;

    public override void OnStart()
    {
        player = GameObject.Find("Player");

        speed = enemy.speed;
        attackRange = enemy.attackRange;
    }

    public override void OnUpdate()
    {
        facePlayer();

        if (enemy.enemydDistanceFromPlayer() <= attackRange) //Enemy is in attack range, then attack player
        {
            stateMachineManager.SetNewState(attackState);
        }
        else
        {
            animator.SetTrigger("run");
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    public override void OnLateUpdate() { }

    Vector3 randomPositionNearPlayer()
    {
        float x = player.transform.position.x + Random.Range(-15, 15);
        float y = player.transform.position.y + Random.Range(-15, 15);
        return new Vector3(x, y, 0);
    }

    void facePlayer()
    {
        if (enemy.transform.position.x < player.transform.position.x)
        {
            enemy.transform.rotation = Quaternion.identity;
        }

        if (enemy.transform.position.x > player.transform.position.x)
        {
            enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
