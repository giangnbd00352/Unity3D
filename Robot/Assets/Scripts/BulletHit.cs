using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

    public float weaponDamge = 10;

    Projectile myPc;

    public GameObject bulletExplosion;
    // Use this for initialization

    void Awake()
    {
        myPc = GetComponentInParent<Projectile>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Shootable")
        {
            myPc.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                EnemyHeal hurtEnemy = other.gameObject.GetComponent<EnemyHeal>();
                hurtEnemy.addDamge(weaponDamge);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shootable")
        {
            myPc.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                EnemyHeal hurtEnemy = other.gameObject.GetComponent<EnemyHeal>();
                hurtEnemy.addDamge(weaponDamge);
            }
        }
    }

}
