using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeal : MonoBehaviour {

    public float maxHeal = 30;
    float currentHeal;
	// Use this for initialization
	void Start () {
        currentHeal = maxHeal;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamge(float damge)
    {
        currentHeal -= damge;
        if(currentHeal <= 0)
        {
            makeDead();
        }
    }

    void makeDead()
    {
        Destroy(gameObject);
    }
}
