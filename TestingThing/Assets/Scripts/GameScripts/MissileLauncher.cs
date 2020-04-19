﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour {

    private Transform target;
    public GameObject missile;
    public float force = 200;
    private Gravity gravity;
    private MeteorController meteorController;

    public float updateTarget;
    private float updateTime;
    private float time;
    public float rateOfFire;

    public Transform emitter;


    public void Init(MeteorController controller, Gravity gravity)
    {
        meteorController = controller;
        this.gravity = gravity;
        transform.LookAt(gravity.transform.position);
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
            target = meteorController.getClosest(transform.position).transform;
            updateTime = 0;
        }
        time += Time.deltaTime;
        if (time >= rateOfFire)
        {
            //Shoot
            GameObject tempMissile = Instantiate(missile, emitter.position, emitter.rotation, null);


            Vector3 heading = -transform.position + target.position;
            heading = heading / heading.magnitude;
            tempMissile.GetComponent<Rigidbody>().AddForce(heading * force);
            //tempMissile.GetComponent<Missile>().Init(gravity);
            //gravity.AddObject(tempBullet.GetComponent<Rigidbody>());
            time = 0;
        }

    }
}