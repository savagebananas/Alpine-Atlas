using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject environmentReference;

    public GameObject tree;
    public GameObject campfire;

    public float numberOfTrees;
    public float numberOfcampfires;

    public float xSpread;
    public float ySpread;

    void Start()
    {
        for (int i = 0; i < numberOfTrees; i++) PlaceItems(tree);
        for (int i = 0; i < numberOfcampfires; i++) PlaceItems(campfire);
    }

    void PlaceItems(GameObject o)
    {
        Vector2 randPos = new Vector2(Random.Range(-xSpread, xSpread), Random.Range(-ySpread, ySpread));
        GameObject clone = Instantiate(o, randPos, Quaternion.identity);
        clone.transform.parent = environmentReference.transform;
    }
}
