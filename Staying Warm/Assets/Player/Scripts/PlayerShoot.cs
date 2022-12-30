using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectile;
    public float power;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot() 
    {
        Vector2 playerToCursorVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;  
        playerToCursorVector.Normalize();
        float playerToCursorAngle = Mathf.Atan2(playerToCursorVector.y, playerToCursorVector.x) * Mathf.Rad2Deg;

        GameObject snowball = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, playerToCursorAngle));
        snowball.GetComponent<Rigidbody2D>().AddForce(playerToCursorVector.normalized * power, ForceMode2D.Impulse);
    }

}
