using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    public Gravity gravity;
    public Planet planet;
    public MeteorController meteorController;
    public GameObject turret;
    public Planet moon;

    public float cooldown = 1;
    private float time = 0;
    private bool canShoot = true;

    public GameObject bullet;
    public float bulletForce = 300;
	// Use this for initialization
	void Start () {
        planet.GeneratePlanet();
        if(moon != null)
        {
            moon.GeneratePlanet();
        }
        
	}

    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;

        if(time >= cooldown)
        {
            canShoot = true;
        }

        if (Input.GetMouseButton(0) && GetComponent<UIController>().manualFire && canShoot)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 pos = Camera.main.transform.position;
                Vector3 dir = hit.point - pos;

                canShoot = false;
                time = 0;
                GameObject tempBullet = Instantiate(bullet, pos, Quaternion.LookRotation(dir), meteorController.transform);


                dir = dir / dir.magnitude;
                tempBullet.GetComponent<Rigidbody>().AddForce(dir * bulletForce);
                tempBullet.GetComponent<Bullet>().Init(gravity, true);
            }
        }else if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                
                Transform objectHit = hit.transform;
                if(objectHit.tag == "Planet" || objectHit.tag == "Moon")
                {
                    GetComponent<UIController>().BuyTurret(hit.point, objectHit.transform, meteorController, gravity);
                    Debug.Log("Selected" + hit.point);

                }
            }
        }
    }
        
}
