using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllCamera : MonoBehaviour {

    public Transform Player;
    public float dis;
	// Use this for initialization
	void Start () {
        dis = Mathf.Abs(Player.transform.position.y - transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Player.transform.position.x, Player.position.y + dis, transform.position.z);
	}
}
