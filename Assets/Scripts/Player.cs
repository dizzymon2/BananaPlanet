using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Player: MonoBehaviour
{
    public ParticleSystem explosion;
    public UnityEngine.GameObject completeMessage; 
    public Shooter shooter;
    public float banana_X, banana_Y, banana_Z; 

    Rigidbody2D rb2D;
    void Start()
    {
        transform.position = new Vector3(banana_X, banana_Y, banana_Z);
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        GetComponent<BoxCollider2D>();
        rb2D  =  GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            //gameObject.SetActive(false);  
            StartCoroutine(MessageManager());
            ResetBanana();
        }
        if (collision.tag == "Wall")
        {
            Instantiate(explosion,transform.position,Quaternion.identity);
            ResetBanana();
        }
    }
    
    void ResetBanana()
    {
        rb2D.velocity = Vector2.zero;
        transform.position = new Vector3(banana_X, banana_Y, banana_Z);
        shooter.swipeOK = true;
    }
    IEnumerator MessageManager()
    {
        completeMessage.SetActive(true);
        yield return new WaitForSeconds(2);
        completeMessage.SetActive(false);
    }
}
