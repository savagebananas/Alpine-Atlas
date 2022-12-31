using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    public float damage;
    public float power;
    public float attackSpeed;
    public float attackRange;
    [HideInInspector] public Rigidbody2D rb;
    private Animator animator;

    public StateMachineManager stateMachineManager;
    public State enemyHurtState;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void hurt(float damage)
    {
        health -= damage;
        animator.SetTrigger("hurt");
        StartCoroutine(Reset());
        stateMachineManager.SetNewState(enemyHurtState);
    }

    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.2f);
        rb.velocity = Vector3.zero;
    }

    public float enemydDistanceFromPlayer()
    {
        float differenceX = player.transform.position.x - transform.position.x;
        float differenceY = player.transform.position.y - transform.position.y;
        return Mathf.Sqrt(differenceX * differenceX + differenceY * differenceY);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
