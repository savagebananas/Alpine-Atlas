using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject environmentReference;

    public GameObject tree;
    public GameObject campfire;
    public GameObject bush;
    public GameObject bigRock;
    public GameObject snowman;
    public GameObject christmasTree;
    public GameObject spawner;

    public float numberOfTrees;
    public float numberOfcampfires;
    public float numberOfBush;
    public float numberOfBigRock;
    public float numberOfSnowman;
    public float numberOfChristmasTree;
    public float numberOfSpawners;

    public float xSpread;
    public float ySpread;

    private float timer = 20;

    void Start()
    {
        for (int i = 0; i < numberOfTrees; i++) PlaceItems(tree);
        for (int i = 0; i < numberOfcampfires; i++) PlaceItems(campfire);
        for (int i = 0; i < numberOfBush; i++) PlaceItems(bush);
        for (int i = 0; i < numberOfBigRock; i++) PlaceItems(bigRock);
        for (int i = 0; i < numberOfSnowman; i++) PlaceItems(snowman);
        for (int i = 0; i < numberOfChristmasTree; i++) PlaceItems(christmasTree);
        for (int i = 0; i < numberOfSpawners; i++) PlaceItems(spawner);
    }

    void PlaceItems(GameObject o)
    {
        Vector2 randPos = new Vector2(Random.Range(-xSpread, xSpread), Random.Range(-ySpread, ySpread));
        GameObject clone = Instantiate(o, randPos, Quaternion.identity);
        clone.transform.parent = environmentReference.transform;
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            PlaceItems(spawner);
            timer = 10;
        }
    }
}
