using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    public Vector3 startPoint, endPoint;
    public ParticleSystem explosion;
    [HideInInspector]
    public bool start = true, end = false;
    public List<Vector3> movingPoints = new List<Vector3>();
    public List<bool> boolPoints = new List<bool>();
    public float cometSpeed = 10,waitingTime;
    private float t = 0f;

    void Start()
    {
        transform.position = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == startPoint)
        {
            start = true;
            end = false;
        }//시작 지점 도착
        if (transform.position == endPoint)
        {
            start = false;
            end = true;
        }//끝 지점 도착

        if (start && !end)
        {
            t += Time.deltaTime;
            if (t * 3f >= waitingTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPoint, cometSpeed);
            }
        }
        if (!start && end)
        {
            transform.position = startPoint;
            t = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
