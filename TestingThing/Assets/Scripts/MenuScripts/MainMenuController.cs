using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {


    public Planet planet;
    public Planet moon;
    public Planet sun;
	// Use this for initialization
	void Start () {
        planet.GeneratePlanet();
        moon.GeneratePlanet();
        sun.GeneratePlanet();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
