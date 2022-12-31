using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Gradient lightColor;
    [SerializeField] private GameObject light;

    private int days;
    public int Days => days;

    private float time = 50;

    private bool canChangeDay = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (time > 500)
        {
            time = 0;
        }
        if ((int)time  == 250 && canChangeDay)
        {
            canChangeDay = false;
            days++;
        }
        if (time == 255)
            canChangeDay = true;

<<<<<<< HEAD
        time += Time.deltaTime * 10;
        light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = lightColor.Evaluate(time * 0.002f);
=======
        time += Time.deltaTime;
        light.GetComponent<Light2D>().color = lightColor.Evaluate(time * 0.002f);
>>>>>>> parent of e7a34eb (Reusable Fire)
    }
}
