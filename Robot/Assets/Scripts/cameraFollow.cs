using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing = 5;

    Vector3 offset;

    float lowY;
    // Use this for initialization
    void Start () {
        offset = transform.position - target.position;

        lowY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position,targetCamPos,smoothing * Time.deltaTime);

        if(transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
        if (transform.position.y > lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
        if (transform.position.x < 1)
        {
            transform.position = new Vector3(1, lowY, transform.position.z);
        }

    }
}
