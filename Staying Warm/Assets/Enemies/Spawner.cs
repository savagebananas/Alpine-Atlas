using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime;
    private float timer;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        float distanceToPlayer =  Vector2.Distance(this.transform.position, player.transform.position);
        if (15 < distanceToPlayer && distanceToPlayer < 30) //spawn only when far from camera but not too far
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                timer = spawnTime;
            }
        }

    }
}
