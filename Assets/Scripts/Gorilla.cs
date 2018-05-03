using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorilla : MonoBehaviour {
    public List<Vector3> movingPoints = new List<Vector3>();
    public List<bool> boolPoints = new List<bool>();
	private GorillaRenderer gR;
    public float gorillaSpeed=10;
    [HideInInspector]
    public bool start=true, end=false;
    // Use this for initialization
    void Start () {
        transform.position = movingPoints[0];
		gR= GetComponent<GorillaRenderer> ();
		print (movingPoints.Count );
		gR.lr.positionCount = movingPoints.Count;
		gR.lr.SetPositions (movingPoints.ToArray ());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == movingPoints[0])
        {
            start = true;
            end = false;
        }//시작 지점 도착
        if (transform.position == movingPoints[movingPoints.Count - 1])
        {
            start = false;
            end = true;
        }//끝 지점 도착
        for (int i = 0; i < movingPoints.Count; i++)
        {
            if(transform.position==movingPoints[i])
            {
                for (int j = 0; j < boolPoints.Count; j++)
                    boolPoints[j] = false;
                boolPoints[i] = true;
            }
        }
        if (start && !end)
        {
            if (boolPoints[0])
                transform.position = Vector3.MoveTowards(transform.position, movingPoints[1], gorillaSpeed);
            if (boolPoints[1])
                transform.position = Vector3.MoveTowards(transform.position, movingPoints[2], gorillaSpeed);
        }
        if (!start && end)
        {
            if (boolPoints[2])
                transform.position = Vector3.MoveTowards(transform.position, movingPoints[1], gorillaSpeed);
            if (boolPoints[1])
                transform.position = Vector3.MoveTowards(transform.position, movingPoints[0], gorillaSpeed);
        }
    }
}
