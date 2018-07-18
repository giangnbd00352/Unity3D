using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour {

    public GameObject obj;
    float speed;
    Vector3 firstPosition;
    // Use this for initialization
    void Start () {
        speed = 2f;
        firstPosition = obj.transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        obj.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        Vector3 getPosition = obj.transform.localPosition;

        if (Vector3.Distance(firstPosition, getPosition) > 5)
        {
            speed = -speed;
            obj.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }
}
