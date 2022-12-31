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

    public float numberOfTrees;
    public float numberOfcampfires;
    public float numberOfBush;
    public float numberOfBigRock;
    public float numberOfSnowman;
    public float numberOfChristmasTree;

    public float xSpread;
    public float ySpread;

    void Start()
    {
        for (int i = 0; i < numberOfTrees; i++) PlaceItems(tree);
        for (int i = 0; i < numberOfcampfires; i++) PlaceItems(campfire);
        for (int i = 0; i < numberOfBush; i++) PlaceItems(bush);
        for (int i = 0; i < numberOfBigRock; i++) PlaceItems(bigRock);
        for (int i = 0; i < numberOfSnowman; i++) PlaceItems(snowman);
        for (int i = 0; i < numberOfChristmasTree; i++) PlaceItems(christmasTree);
    }

    void PlaceItems(GameObject o)
    {
        Vector2 randPos = new Vector2(Random.Range(-xSpread, xSpread), Random.Range(-ySpread, ySpread));
        GameObject clone = Instantiate(o, randPos, Quaternion.identity);
        clone.transform.parent = environmentReference.transform;
    }
}
