using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBehaviour : MonoBehaviour {

    public Vector3 rotationSpeed;

    private Vector3 currentSpinn;
	// Update is called once per frame
	void Update () {

        Vector3 temp = new Vector3(rotationSpeed.x * Time.deltaTime, rotationSpeed.y * Time.deltaTime, rotationSpeed.z * Time.deltaTime);

        transform.Rotate(temp);
	}
}
