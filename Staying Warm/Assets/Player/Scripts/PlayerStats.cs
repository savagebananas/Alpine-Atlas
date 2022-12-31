using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Slider tempSlider;
    public float maxTemp;
    public float temp;
    public float tempFallRate;
    
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sprite;
    public bool isHurt;

    private void Start()
    {
        tempSlider.maxValue = maxTemp;
        tempSlider.value = maxTemp;
        temp = maxTemp;
    }

    void Update()
    {
        if (tempSlider.value >= 0)
        {            
            temp -= Time.deltaTime / tempFallRate;
            tempSlider.value = temp;

        }

        if(temp >= maxTemp)
        {
            temp = maxTemp;
        }
    }

    public void Hurt(float damage, float knockbackPower, Vector2 attackingColliderToPlayerVector)
    {
        isHurt = true;
        temp -= damage;

        if (temp > 0)
        { 
            StartCoroutine(hurtCounter());
        }
        else
        {
            Debug.Log("Player Dead");
            //animator.SetTrigger("dead");
            //knockback(5f, attackingColliderToPlayerVector);
        }
    }

    IEnumerator hurtCounter()
    {
        animator.SetTrigger("hurt");
        sprite.color = new Color(0, 255, 255, 160);
        yield return new WaitForSeconds(0.5f);
        sprite.color = new Color(255, 255, 255, 255);
        animator.SetTrigger("isIdle");
        isHurt = false;
    }
}
