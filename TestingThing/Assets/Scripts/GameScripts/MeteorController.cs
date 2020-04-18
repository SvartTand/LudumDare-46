using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour {

    public float spawnrate;
    private float timer;
    public Transform planet;
    public GameObject meteor;
    public float distance = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= spawnrate)
        {
            GameObject tempMeteor = Instantiate(meteor, Random.onUnitSphere * distance, transform.rotation, this.transform);
            tempMeteor.GetComponent<Meteor>().Init(planet);
            timer = 0;
        }
	}
}
