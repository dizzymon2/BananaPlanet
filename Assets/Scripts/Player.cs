using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player: MonoBehaviour
{
    public GameObject complete;
    public Planet goal;
    private CircleCollider2D circleCol;
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<BoxCollider2D>();
        //circleCol = goal.GetComponent<CircleCollider2D>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
            complete.SetActive(true);
    }
}
