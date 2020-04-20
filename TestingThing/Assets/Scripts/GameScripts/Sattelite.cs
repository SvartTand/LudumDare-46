using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sattelite : MonoBehaviour {

    private MeteorController meteorController;
    private Transform rotateTarget;
    private Transform target;
    public float speed = 5;
    private float updateTime = 0;
    public float updateTarget = 2;
    private float time = 0;
    public float rateOfFire = 10;

    public GameObject laser;
    public Transform emitter;

    public TrailRenderer trail;

	public void Init()
    {

    }

    private void Update()
    {
        if (target == null)
        {
            Meteor m = meteorController.GetRandom();
            if (m != null)
            {
                target = m.transform;
            }

        }

        updateTime += Time.deltaTime;
        if (updateTime >= updateTarget)
        {
            Meteor m = meteorController.GetRandom();
            if (m != null)
            {
                target = m.transform;
            }
            updateTime = 0;
        }
        time += Time.deltaTime;
        if (time >= rateOfFire && target != null)
        {
            //Shoot
            GameObject tempMissile = Instantiate(laser, emitter.position, emitter.rotation, meteorController.transform);
            //audioS.Play();

            Vector3 heading = -transform.position + target.position;
            heading = heading / heading.magnitude;
            //tempMissile.GetComponent<Rigidbody>().AddForce(heading * force);
            tempMissile.GetComponent<Missile>().Init(target, meteorController);
            //gravity.AddObject(tempBullet.GetComponent<Rigidbody>());
            time = 0;
        }
    }
}
