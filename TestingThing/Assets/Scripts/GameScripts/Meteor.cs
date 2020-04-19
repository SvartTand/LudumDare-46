using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private MeteorController controller;
    public float dmg = 1;

    public ParticleSystem particles;
    public TrailRenderer trail;

    public void Init(Transform target, MeteorController cont)
    {
        controller = cont;
        rb = GetComponent<Rigidbody>();
        transform.LookAt(target);
        Vector3 heading = - transform.position + target.position;
        heading = heading / heading.magnitude;
        rb.AddForce(heading * speed);


    }

    public void DestroyIt(bool b)
    {
        controller.Remove(this, b);
        trail.transform.parent = transform.parent;
        particles.transform.parent = transform.parent;
        particles.Stop();
        particles.transform.localScale = new Vector3(1,1,1);
        Destroy(particles, 2);
        Destroy(trail, 2);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Planet")
        {
            collision.collider.GetComponent<HealthComponent>().TakeDmg(dmg);
            DestroyIt(false);
        }
        else if (collision.collider.tag == "Projectile")
        {
            DestroyIt(true);
        }
        
        Debug.Log(collision.collider.tag);
    }
}
