using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    GameObject player;
    public Animator eButton;
    public Animator transition;
    public AudioManager audioManager;

    public GameObject confetti;

    void Start()
    {
        player = GameObject.Find("Player");
        transition = GameObject.Find("Panel").GetComponent<Animator>();
        audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, this.transform.position) < 4)
        {
            eButton.SetFloat("Float", 1);
            if (Input.GetKeyDown(KeyCode.E))
            {
                eButton.SetTrigger("Press");
                transition.SetTrigger("FadeOut");
                audioManager.PlaySound("Win");
                Instantiate(confetti, transform.position + new Vector3(0, 0.6f, 0), Quaternion.Euler(-90, 0, 0));

            }
        }
        else
        {
            eButton.SetFloat("Float", 3);
        }
    }
}
