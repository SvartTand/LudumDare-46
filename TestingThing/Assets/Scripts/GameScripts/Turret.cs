using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    public GameObject bullet;
    public float force = 200;
    private Gravity gravity;
    private MeteorController meteorController;

    public float updateTarget;
    private float updateTime;
    private float time;
    public float rateOfFire;


    public void Init(MeteorController controller, Gravity gravity)
    {
        meteorController = controller;
        this.gravity = gravity;
    }

    private void Update()
    {
        if(target == null)
        {
            Meteor m = meteorController.getClosest(transform.position);
            if(m != null)
            {
                target = m.transform;
            }
            
        }

        updateTime += Time.deltaTime;
        if (updateTime >= updateTarget)
        {
            target = meteorController.getClosest(transform.position).transform;
            updateTime = 0;
        }

        if(time >= rateOfFire)
        {
            //Shoot
            GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation, null);


            Vector3 heading = transform.position - target.position;
            heading = heading / heading.magnitude;
            tempBullet.GetComponent<Rigidbody>().AddForce(heading * force);
            tempBullet.GetComponent<Bullet>().Init(gravity);
            gravity.AddObject(tempBullet.GetComponent<Rigidbody>());
            time = 0;
        }
    }
}
