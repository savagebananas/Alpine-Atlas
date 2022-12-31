using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public float healRadius;
    public float healAmount;
    private bool fireOn;
    private bool fireUsed;

    public float fireDuration;
    private float fireTimer = -1f;

    public float timePerHeal;
    private float healTimer;

    private GameObject player;

    public Animator animator;

    private float time = 15;

    void Start()
    {
        player = GameObject.Find("Player");
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFireVisuals();

        if (Vector2.Distance(this.transform.position, player.transform.position) <= healRadius && fireUsed == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                fireTimer = fireDuration;
                animator.SetTrigger("Press");
            }
        }


        if (fireTimer >= 0)
        {
            fireOn = true;
            fireTimer -= Time.deltaTime;
        }

        else if (fireOn == true && fireTimer <= 0)
        {
            fireOn = false;
            fireUsed = true;

            //Temporary, make new animation for fire dying
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }

        FireHeal();
        ResetFire();
    }

    void FireHeal()
    {
        if (fireOn && Vector2.Distance(this.transform.position, player.transform.position) <= healRadius) //player close enough
        {
            if (healTimer <= 0)
            {
                player.GetComponent<PlayerStats>().temp += healAmount;
                healTimer = timePerHeal;

            }
            else
            {
                healTimer -= Time.deltaTime;
            }
        }
    }

    void UpdateFireVisuals()
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) < healRadius) //inside radius
        {
            animator.SetTrigger("fadeIn");
            animator.SetFloat("Float", 1);
        }
        if (Vector2.Distance(this.transform.position, player.transform.position) > healRadius) //outside radius
        {
            animator.SetTrigger("fadeOut");
            animator.SetFloat("Float", 3);
        }
    }

    void ResetFire()
    {
        if (time > 0) 
        {
            time -= Time.deltaTime;
            Debug.Log((int)time);
        }
        else
        {
            Debug.Log("reset fire");
            fireUsed = false;
            animator.SetBool("FireUsed", false);
            time = 15; //set to 500
        }


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, healRadius);
    }
}
