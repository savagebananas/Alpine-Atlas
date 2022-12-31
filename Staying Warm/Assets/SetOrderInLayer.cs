using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOrderInLayer : MonoBehaviour
{
    public Renderer renderer;
    public float offset;
    private GameObject referenceObject;
    public bool attachedToPlayer;

    private void Start()
    {
        if (attachedToPlayer)
        {
            referenceObject = GameObject.Find("Player");
        }
        if (renderer == null) //temporary fix to add particle renderers
        {
            renderer = gameObject.GetComponent<ParticleSystem>().GetComponent<Renderer>();
        }
    }

    private void LateUpdate()
    {
        if (referenceObject != null)
        {
            renderer.sortingOrder = referenceObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }
        else
        {
            renderer.sortingOrder = -(int)((transform.position.y + offset) * 100);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y + offset, 0), 0.05f);
    }
}
