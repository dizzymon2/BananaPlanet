using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Shooter : MonoBehaviour
{
    public GameObject lineRenderer;
    public Camera mainCamera;
    private Transform player;
    private bool tap, swipeLeft, swipeRight, speedSwitch;
    [HideInInspector]
    public bool isShoot = false;
    private Vector2 startTouch, swipeDelta, currentTouch, endTouch;
    public Vector3 slingVector;
    private Vector3 emptyVector;
    private Vector3 emptyVector2;
    private Vector3 sumVector;
    Vector3[] arr;
    private float passTime, swipeSpeed; //constantSpeed;
    private Vector2 page1, page2, page3;
    public Camera stopCamera;
    public float cameraSpeed;
    [HideInInspector]
    public bool swipeOK;
    public bool gravityOK = false;
    LineRenderer lr;
    public GameObject banana;
    public Rigidbody2D rb;
    public float force;
    public GameObject shooter;


    // Use this for initialization

    void Start()
    {
        lr = lineRenderer.GetComponent<LineRenderer>();
        rb = banana.GetComponent<Rigidbody2D>();
        swipeOK = true;
        emptyVector2 = shooter.transform.position;//new Vector3(-500, 0, 0);
        player = mainCamera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (swipeOK == true)
        {
            tap = swipeLeft = swipeRight = speedSwitch = false;

            #region Standalone Inputs

            if (Input.GetMouseButtonDown(0))
            {
                gravityOK = false;
                Debug.Log("탭이다");
                swipeDelta = Vector2.zero;
                tap = true;
                startTouch = stopCamera.ScreenToWorldPoint(Input.mousePosition);
                currentTouch = stopCamera.ScreenToWorldPoint(Input.mousePosition);
                emptyVector = player.position;
            }


            if (Input.GetMouseButton(0))
            {
                gravityOK = false;
                //emptyVector.x -= (stopCamera.ScreenToWorldPoint(Input.mousePosition).x - currentTouch.x);
                currentTouch = stopCamera.ScreenToWorldPoint(Input.mousePosition);
                slingVector = startTouch - currentTouch;
                //mainCamera.transform.position = emptyVector;
                sumVector = emptyVector2 + slingVector * 10;
                Vector3[] arr = { emptyVector2, sumVector };
                lr.SetPositions(arr);
            }

            else if (Input.GetMouseButtonUp(0))
            {
                sumVector = emptyVector2;
                Vector3[] arr = { emptyVector2, sumVector };
                lr.SetPositions(arr);
                isShoot = true;
                gravityOK = true;
                tap = false;
                endTouch = stopCamera.ScreenToWorldPoint(Input.mousePosition);
                slingVector = startTouch - endTouch;
                force = Mathf.Sqrt((slingVector.x) * (slingVector.x) + (slingVector.y) * (slingVector.y));
            }
            #endregion
        }

        if (isShoot)
        {
            isShoot = false;
            gravityOK = true;
            swipeDelta.x = endTouch.x - startTouch.x;
            swipeSpeed = Mathf.Sqrt((endTouch.x - currentTouch.x) * (endTouch.x - currentTouch.x) + (endTouch.y - currentTouch.y) * (endTouch.y - currentTouch.y));
            rb.AddForce(slingVector * force);
        }
    }
}