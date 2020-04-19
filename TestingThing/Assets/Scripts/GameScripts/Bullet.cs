using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float lifeTime = 1;
    private float time = 0;
    private Transform target;

    private Gravity gravity;

    public AudioSource source;

    public void Init(Gravity g, bool fromCamera)
    {
        if (fromCamera)
        {
            source.Play();
        }
        gravity = g;
    }
	
	// Update is called once per frame
	void Update () {
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
