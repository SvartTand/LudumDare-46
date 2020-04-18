﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform planet;
    public Gravity gravity;
    public Transform emitter;
    public GameObject Bullet;
    public float force = 100;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    public void Fire()
    {
        GameObject tempBullet = Instantiate(Bullet, emitter.position, transform.rotation, null);


        Vector3 heading = emitter.transform.position - transform.position;
        heading = heading / heading.magnitude;
        tempBullet.GetComponent<Rigidbody>().AddForce(heading * force);
        tempBullet.GetComponent<Bullet>().Init(gravity);
        gravity.AddObject(tempBullet.GetComponent<Rigidbody>());
    }

    public void SetAngle(float a)
    {
        transform.rotation = Quaternion.Euler(a-90, 0, 0);

    }


}
