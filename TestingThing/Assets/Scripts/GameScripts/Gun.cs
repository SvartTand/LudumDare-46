using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform planet;
    public Gravity gravity;
    public Transform emitter;
    public GameObject Bullet;
    public float force = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject tempBullet = Instantiate(Bullet, emitter.position, transform.rotation, transform);
            

            Vector3 heading = emitter.transform.position - transform.position;
            heading = heading / heading.magnitude;
            tempBullet.GetComponent<Rigidbody>().AddForce(heading * force);
            gravity.AddObject(tempBullet.GetComponent<Rigidbody>());
        }
    }
}
