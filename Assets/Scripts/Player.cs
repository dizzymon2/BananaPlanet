using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player: MonoBehaviour
{
    private Transform myTransform;

    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        myTransform = transform;
    }

    void FixedUpdate()
    {
    }
}
