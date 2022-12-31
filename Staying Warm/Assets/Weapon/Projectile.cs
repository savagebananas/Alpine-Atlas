using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float power;
    public GameObject impaceEffect;

    private void Start()
    {
        StartCoroutine(DestroySnowball());
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.hurt(damage);
            enemy.rb.AddForce((enemy.transform.position - this.transform.position).normalized * power, ForceMode2D.Impulse);
            var particle = Instantiate(impaceEffect, collider.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroySnowball()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
