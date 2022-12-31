using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    public GameObject player;
    public float distance;
    private bool facingRight;
    private bool facingLeft;

    void Update()
    {
        setPosition();
        setRotation();
    }

    void setPosition()
    {
        Vector2 playerToCursorVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
        playerToCursorVector.Normalize();
        transform.position = (Vector2)player.transform.position + playerToCursorVector * distance;

    }

    void setRotation()
    {
        Vector2 playerToCursorVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
        playerToCursorVector.Normalize();
        float playerToCursorAngle = Mathf.Atan2(playerToCursorVector.y, playerToCursorVector.x) * Mathf.Rad2Deg;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < transform.position.x)
        {
            facingRight = false;
            facingLeft = true;
        }
        if (mousePos.x > transform.position.x)
        {
            facingRight = true;
            facingLeft = false;
        }

        if (facingRight == true)
        {
            transform.localRotation = Quaternion.Euler(0, 0, playerToCursorAngle);
            Vector3 tmpScale = transform.localScale;
            tmpScale.y = 1;
            transform.localScale = tmpScale;
        }

        if (facingLeft == true)
        {
            transform.localRotation = Quaternion.Euler(0, 0, (playerToCursorAngle));

            Vector3 tmpScale = transform.localScale;
            tmpScale.y = -1;
            transform.localScale = tmpScale;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 playerToCursorVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
        playerToCursorVector.Normalize();
        float playerToCursorAngle = Mathf.Atan2(playerToCursorVector.y, playerToCursorVector.x) * Mathf.Rad2Deg;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(player.transform.position, playerToCursorVector);
    }
}
