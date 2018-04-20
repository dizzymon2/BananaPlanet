using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour {
    public List<Planet> planets = new List<Planet>();
    public Player player;
    public float gravityRadius;
    [HideInInspector]
    public float distance;
    public Shooter shooter;
	// Use this for initialization
	void Start (){

    }

    void Update () {
        for(int i=0;i<planets.Count;i++)
        {
            distance = Vector3.Distance(player.transform.position, planets[i].transform.position);
            if(shooter.gameStart)
            {
                if (distance <= gravityRadius)
                    shooter.gravityOK = true;
                else
                    shooter.gravityOK = false;
                planets[i].Attract(player.transform);
            }
        }
    }
}
