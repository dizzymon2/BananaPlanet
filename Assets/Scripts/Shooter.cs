using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Shooter : MonoBehaviour
{
    private Vector2 startTouch, currentTouch, endTouch;
    public Vector3 slingVector,emptyVector2, sumVector,temp;
    public Vector3[] arr;
    public Camera stopCamera;
    public bool swipeOK,isShoot = false, gravityOK = false,gameStart=false;
    public LineRenderer lr;
    public GameObject banana, shooter, lineRenderer;
    public Rigidbody2D rb;
    public float force, cameraSpeed, forceConstant;


    // Use this for initialization

    void Start()
    {
        lr = lineRenderer.GetComponent<LineRenderer>();
        rb = banana.GetComponent<Rigidbody2D>();
        swipeOK = true;
        emptyVector2 = shooter.transform.position;//new Vector3(-500, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (swipeOK == true)
        {
			
            if (Input.GetMouseButtonDown(0))
            {
                gameStart = true;
                gravityOK = false;
                startTouch = stopCamera.ScreenToWorldPoint(Input.mousePosition);
                temp = banana.transform.position;
                currentTouch = stopCamera.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                banana.transform.position = temp;
                rb.velocity = (Vector2.zero);
                gravityOK = false;
                currentTouch = stopCamera.ScreenToWorldPoint(Input.mousePosition);
                slingVector = startTouch - currentTouch;
                sumVector = banana.transform.position + slingVector * 5;
                Vector3[] arr = {banana.transform.position, sumVector };
                lr.SetPositions(arr);
            }

            else if (Input.GetMouseButtonUp(0))
            {
                sumVector = emptyVector2;
                Vector3[] arr = { banana.transform.position, banana.transform.position };
                lr.SetPositions(arr);
                isShoot = true;
                gravityOK = true;
                endTouch = stopCamera.ScreenToWorldPoint(Input.mousePosition);
                slingVector = startTouch - endTouch;
                force = Mathf.Sqrt((slingVector.x) * (slingVector.x) + (slingVector.y) * (slingVector.y));
				swipeOK = false;
            }
        }

        if (isShoot)
        {
            isShoot = false;
            rb.AddForce(slingVector * force* forceConstant*0.1f);
        }
    }
}