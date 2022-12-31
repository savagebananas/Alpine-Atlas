using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTowardsPoint : MonoBehaviour
{
    public Transform point;
    public float speed;
    public Animator animator;
    void Start()
    {
        animator.SetTrigger("run");
        animator.SetTrigger("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}
