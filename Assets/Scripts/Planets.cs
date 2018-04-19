using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour {
    public List<Planet> planets = new List<Planet>();
    public Player player;
	// Use this for initialization
	void Start ()
    {
        //public Planet attractor;
        //public Planet attractor2;
        //public Planet attractor3;
        //public Planet attractor4;
        //attractor = GameObject.Find("Planet").GetComponent<Planet>();
        //attractor2 = GameObject.Find("Planet").GetComponent<Planet>();
        //attractor3 = GameObject.Find("Planet").GetComponent<Planet>();
        //attractor4 = GameObject.Find("Planet").GetComponent<Planet>();
    }

    // Update is called once per frame
    void Update () {
        for(int i=0;i<planets.Count;i++)
        {
            planets[i].Attract(player.transform);
        }
    }
}
