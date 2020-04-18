using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {


    public Planet planet;
	// Use this for initialization
	void Start () {
        planet.GeneratePlanet();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
