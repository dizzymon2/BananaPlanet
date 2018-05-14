using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPage : MonoBehaviour {

    float timeCheck = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeCheck += Time.deltaTime;
        if (timeCheck > 5f)
            gameObject.SetActive(false);
	}
}
