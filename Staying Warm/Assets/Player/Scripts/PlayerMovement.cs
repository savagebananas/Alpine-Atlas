using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer player;

    [Range(0.1f, 50f)]
    public float moveSpeed;
    public Rigidbody2D rigidbody;

    Vector2 movement;

    public Animator playerAnimator;

    private bool FacingRight = true;

    private void Update()
    {
        //movemnet input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (movement.x != 0 || movement.y != 0) playerAnimator.SetTrigger("isWalking");
        else playerAnimator.SetTrigger("isIdle");

        //make character face mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < transform.position.x) player.flipX = true; 
        if (mousePos.x > transform.position.x) player.flipX = false;
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
