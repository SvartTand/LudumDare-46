using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    public Gravity gravity;
    public Planet planet;
    public MeteorController meteorController;
    public GameObject turret;
	// Use this for initialization
	void Start () {
        planet.GeneratePlanet();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                
                Transform objectHit = hit.transform;
                if(objectHit.tag == "Planet" && GetComponent<UIController>().BuyTurret())
                {
                    Debug.Log("Selected" + hit.point);

                    
                    GameObject temp = Instantiate(GetComponent<UIController>().currentTurret, hit.point, transform.rotation, planet.transform);
                    temp.GetComponent<Turret>().Init(meteorController, gravity);
                }
            }
        }
    }
        
}
