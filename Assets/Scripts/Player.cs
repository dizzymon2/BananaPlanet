using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player: MonoBehaviour
{
    public ParticleSystem explosion;
    public UnityEngine.GameObject complete;
    public GameObject goal;
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<BoxCollider2D>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            gameObject.SetActive(false);
            complete.SetActive(true);
        }
        if (collision.tag == "Wall")
        {
            Instantiate(explosion,transform.position,Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
