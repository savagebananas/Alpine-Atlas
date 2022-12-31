using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyHurt : State
{
    public State followState;
    public GameObject enemy;
    public GameObject explosionParticles;
    public CinemachineImpulseSource impulse;
    public override void OnLateUpdate() { }

    public override void OnStart()
    {
        StartCoroutine(Hurt());
    }

    public override void OnUpdate() { }

    public IEnumerator Hurt()
    {
        enemy.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        animator.SetTrigger("hurt");
        if (enemy.GetComponent<Enemy>().health <= 0) //enemy dead
        {
            impulse.GenerateImpulse(0.5f);
            Instantiate(explosionParticles, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.2f);
            enemy.GetComponent<SpriteRenderer>().color = new Color(0, 255, 255, 100);
            Destroy(enemy);
        }
        else //enemy damaged but not dead
        {
            impulse.GenerateImpulse(0.2f);
            yield return new WaitForSeconds(0.2f);
            animator.SetTrigger("run");
            stateMachineManager.SetNewState(followState);
            //enemy.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
 
    }
}
