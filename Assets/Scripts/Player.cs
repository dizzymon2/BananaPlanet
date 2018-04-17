using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player: MonoBehaviour
{

    public Planet attractor;
    public Planet attractor2;
    public Planet attractor3;
    public Planet attractor4;
    private Transform myTransform;

    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        myTransform = transform;
        attractor = GameObject.Find("Planet").GetComponent<Planet>();
        attractor2 = GameObject.Find("Planet").GetComponent<Planet>();
        attractor3 = GameObject.Find("Planet").GetComponent<Planet>();
        attractor4 = GameObject.Find("Planet").GetComponent<Planet>();
    }

    void FixedUpdate()
    {
        if (attractor)
        {
            attractor.Attract(myTransform);
        }
        if (attractor2)
        {
            attractor2.Attract(myTransform);
        }
        if (attractor3)
        {
            attractor3.Attract(myTransform);
        }
        if (attractor4)
        {
            attractor4.Attract(myTransform);
        }
    }
}
