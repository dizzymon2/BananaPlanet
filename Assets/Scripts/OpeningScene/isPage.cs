using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPage : MonoBehaviour {
    public StoryManager storyManager;
    public float changeTime;

    float timeCheck = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeCheck += Time.deltaTime;
        if (timeCheck > changeTime)
        {
            Debug.Log("BOOL값을 바꾸려 시도");
            storyManager.storyStart = true;
            Debug.Log("change!");
            gameObject.SetActive(false);
        }
	}
}
