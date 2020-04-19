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

    public HealthComponent hp;

    public bool canSplit;
    public int splitAmount;
    public GameObject splittedMeteor;

    public ParticleSystem explosion;

    public void Init(Transform target, MeteorController cont)
    {
        controller = cont;
        rb = GetComponent<Rigidbody>();
        if(target != null)
        {
            transform.LookAt(target);
        }
        
       
        rb.AddForce(transform.forward * speed);


    }

    public void DestroyIt(bool b)
    {
        if (!b || hp.TakeDmg(1))
        {
            if (canSplit)
            {
                int amount = Random.Range(0, splitAmount);
                for (int i = 0; i < splitAmount; i++)
                {
                    GameObject tempMeteor = Instantiate(splittedMeteor, transform.position, transform.rotation, controller.transform);
                    tempMeteor.transform.rotation = transform.rotation;
                    tempMeteor.transform.Rotate(new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)));
                    //tempMeteor.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
                    controller.Add(tempMeteor.GetComponent<Meteor>());
                    tempMeteor.GetComponent<Meteor>().Init(null, controller);
                }
            }
            ParticleSystem temp = Instantiate(explosion, transform.position, transform.rotation, controller.transform);
            Destroy(temp, 4);
            controller.Remove(this, b);
            trail.transform.parent = transform.parent;
            particles.transform.parent = transform.parent;
            particles.Stop();
            particles.transform.localScale = new Vector3(1, 1, 1);
            Destroy(particles, 2);
            Destroy(trail, 2);
            
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Planet")
        {
            other.GetComponent<HealthComponent>().TakeDmg(dmg);
            if (splitAmount > 0)
            {
                other.GetComponent<Gravity>().CreateCrater(transform.position);
            }
            
            DestroyIt(false);
        }
        else if (other.tag == "Projectile")
        {
            DestroyIt(true);
            Destroy(other.gameObject);
        }

        Debug.Log(other.tag);
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
            Destroy(collision.collider.gameObject);
        }
        
        Debug.Log(collision.collider.tag);
    }
}
