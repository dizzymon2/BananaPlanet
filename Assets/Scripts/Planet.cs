using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{

    public float gravity = -12;
    public Shooter shooter;
    float num;

    public void Attract(Transform body)
    {
        if(shooter.gravityOK)
        {
            Vector3 gravityUp = (body.position - transform.position).normalized;
            Vector3 localUp = body.up;
            num += Time.deltaTime;

            body.GetComponent<Rigidbody2D>().AddForce(gravityUp *gravity*num);

            Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;
            body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime);
        }
    }
}
