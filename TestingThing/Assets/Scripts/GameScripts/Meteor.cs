using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private MeteorController controller;

    public void Init(Transform target, MeteorController cont)
    {
        controller = cont;
        rb = GetComponent<Rigidbody>();

        Vector3 heading = - transform.position + target.position;
        heading = heading / heading.magnitude;
        rb.AddForce(heading * speed);
    }

    public void DestroyIt()
    {
        controller.Remove(this);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        DestroyIt();
    }
}
