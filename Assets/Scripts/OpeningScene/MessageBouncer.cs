using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBouncer : MonoBehaviour {
    public List<Image> messageList = new List<Image>();

    float t = 2;
	// Use this for initialization
	void Start ()
    {

    }	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if(t>4f)
        {
            StartCoroutine(MessageJump());
            t = 0;
        }
	}
    IEnumerator MessageJump()
    {
        Debug.Log("qwe");
        for(int i=0;i<messageList.Count;i++)
        {
            StartCoroutine(Jump(i));
            yield return new WaitForSeconds(0.1f);
        }
        StopCoroutine(MessageJump());
    }
    IEnumerator Jump(int i)
    {
        Vector3 temp = messageList[i].transform.position;
        temp.y += 500f;
        messageList[i].transform.position = temp;
        yield return new WaitForSeconds(0.1f);
        temp.y -= 500f;
        messageList[i].transform.position = temp;
    }
    //IEnumerator BananaGetBig()
    //{
    //    while (banana.transform.localScale.x < 50)
    //    {
    //        banana.transform.localScale += new Vector3(2f, 2f, 2f);
    //        yield return null;
    //    }
    //    StopCoroutine(BananaGetBig());
    //}
}
