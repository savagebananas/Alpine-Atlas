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
    }

    public void Hurt(float damage, Vector2 enemyPosition)
    {
        Debug.Log("Player hurt");
        temp -= damage;
        StartCoroutine(Knockback(enemyPosition));
    }

    IEnumerator Knockback(Vector2 enemyPosition)
    {
        this.GetComponent<Rigidbody2D>().AddForce(((Vector2)transform.position - enemyPosition).normalized * 5, ForceMode2D.Impulse);
        isHurt = true;
        yield return new WaitForSeconds(1f);
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        isHurt = false;
    }

    
}
