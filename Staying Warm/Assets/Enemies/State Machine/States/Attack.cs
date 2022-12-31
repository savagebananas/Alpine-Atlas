using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
    private PlayerStats player;
    public Enemy enemy;
    public State followPlayer;

    private float attackDelay;
    private float damage;
    private float power;
    private float attackRange;

    public float enemyToPlayerDistance;

    private bool playerIsHurt;

    public override void OnStart()
    {
        player = GameObject.Find("Player").GetComponent<PlayerStats>();

        attackDelay = enemy.attackSpeed;
        damage = enemy.damage;
        power = enemy.power;
        attackRange = enemy.attackRange;


        StartCoroutine(AttackDelay());
    }

    public override void OnUpdate()
    {
        enemyToPlayerDistance = enemy.enemydDistanceFromPlayer();
        playerIsHurt = player.isHurt;

        facePlayer();

    }

    public override void OnLateUpdate()
    {

    }

    private IEnumerator AttackDelay()
    {
        //animator.SetTrigger("attack");
        yield return new WaitForSeconds(attackDelay);

        if (enemyToPlayerDistance <= attackRange && !playerIsHurt)
        {
            player.Hurt(damage, enemy.transform.position);
            StartCoroutine(AttackDelay()); //calls the attack again after hitting player
        }

        else //not in attack range
        {
            stateMachineManager.SetNewState(followPlayer);
        }
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
