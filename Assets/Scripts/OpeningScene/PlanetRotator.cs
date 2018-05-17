using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlanetRotator : MonoBehaviour, IPointerDownHandler {
    public Image rotator;
	// Use this for initialization
	void Start () {
		
	}

    public void OnPointerDown(PointerEventData eventData) //이 스크립트가 들어있는 ui가 눌러졌을때 발동한다.
    {
        float x, y;
        RectTransform rt = rotator.GetComponent<RectTransform>();
        RectTransform rt_2 = GetComponent<RectTransform>();
        rotator.transform.position = gameObject.transform.position;
        x = rt_2.rect.width + 50f;
        y = rt_2.rect.height + 50f;
        rt.sizeDelta = new Vector2(x, y);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
