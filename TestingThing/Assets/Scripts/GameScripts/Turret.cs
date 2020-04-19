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

    public Transform emitter;

    public AudioSource audioS;

    public void Init(MeteorController controller, Gravity gravity, Transform par)
    {
        meteorController = controller;
        this.gravity = gravity;
        transform.LookAt(par.position);
        transform.Rotate(new Vector3(180, 0, 0));
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
            Meteor m = meteorController.getClosest(transform.position);
            if (m != null)
            {
                target = m.transform;
            }
            updateTime = 0;

        }
        time += Time.deltaTime;
        if(time >= rateOfFire && target != null)
        {
            //Shoot
            GameObject tempBullet = Instantiate(bullet, emitter.position, emitter.rotation, meteorController.transform);
            audioS.Play();
            Debug.Log(audioS.isPlaying);

            Vector3 heading = -transform.position + target.position;
            heading = heading / heading.magnitude;
            tempBullet.GetComponent<Rigidbody>().AddForce(heading * force);
            tempBullet.transform.LookAt(target);
            tempBullet.GetComponent<Bullet>().Init(gravity, false);
            //gravity.AddObject(tempBullet.GetComponent<Rigidbody>());
            time = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
