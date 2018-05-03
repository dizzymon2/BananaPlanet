﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Ellipse {

	public float xAxis, yAxis;

	public Ellipse (float xAxis, float yAxis){
		this.xAxis = xAxis;
		this.yAxis = yAxis;
	}

	public Vector2 Evaluate (float t){
		float angle = Mathf.Deg2Rad * 360f * t;
		float x = Mathf.Cos (angle) * xAxis;
		float y = Mathf.Sin (angle) * yAxis;
		return new Vector2 (x, y); 
	}


}
