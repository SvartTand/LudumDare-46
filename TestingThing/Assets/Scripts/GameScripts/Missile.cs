using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float lifeTime = 1;
    public float turnSpeed = 5;
    private float time = 0;

    public float maxSpeed;

    private Gravity gravity;

    public Transform target;

    public float speed = 20;
    public float acceleration = 20;
    public CharacterController controller;
    private MeteorController meteorController;

    public void Init(Transform t, MeteorController meteors)
    {
        target = t;
        meteorController = meteors;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Meteor m = meteorController.GetRandom();
            
            if(m == null)
            {
                Destroy(gameObject);
            }
            else
            {
                target = m.transform;
            }
        }
        else
        {
            Vector3 relativePos = target.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);


            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, rotation, turnSpeed * Time.deltaTime);
            
            if (speed <= maxSpeed)
            {
                speed += acceleration;
            }

            Vector3 moveDirection = transform.forward;
            moveDirection *= speed * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.transform.position) <= 4f)
            {
                target.GetComponent<Meteor>().DestroyIt(true);
                Destroy(gameObject);
            }
        }



        time += Time.deltaTime;
        if (time >= lifeTime)
        {
            //gravity.RemoveObject(GetComponent<Rigidbody>());
            Destroy(gameObject);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //gravity.RemoveObject(GetComponent<Rigidbody>());
        Destroy(gameObject);
    }
}
