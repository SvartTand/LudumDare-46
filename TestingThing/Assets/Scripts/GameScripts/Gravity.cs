using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public float range = 100f;
    public float stopRange = 2f;
    public float force = 10;

    public List<Rigidbody> rigidbodies = new List<Rigidbody>();


    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < rigidbodies.Count; i++)
        {
            float dist = Vector3.Distance(rigidbodies[i].transform.position, transform.position);
            if(dist < range && dist > stopRange)
            {

                Vector3 heading = transform.position - rigidbodies[i].transform.position ;
                heading = heading / heading.magnitude;
                rigidbodies[i].AddForce(heading * force *  Time.deltaTime);
            }
        }
        
    }

    public void AddObject(Rigidbody obj)
    {
        rigidbodies.Add(obj);

    }

    public void RemoveObject(Rigidbody rb)
    {
        rigidbodies.Remove(rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "meteor")
        {
            collision.collider.GetComponent<Meteor>().DestroyIt();
            Debug.Log("Meteor Hit Us");
        }
    }
}
