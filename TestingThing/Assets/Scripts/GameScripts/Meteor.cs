using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    public float speed;
    private Rigidbody rb;

    public void Init(Transform target)
    {

        rb = GetComponent<Rigidbody>();

        Vector3 heading = - transform.position + target.position;
        heading = heading / heading.magnitude;
        rb.AddForce(heading * speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
