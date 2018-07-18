using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyBroad : MonoBehaviour {

    public float maxSpeed = 5f;
    public float jumpheight = 15f;

    bool facingRight;
    bool grounded;
    //bool died = false;

    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0;

    Rigidbody2D myBody;
    Animator myAnim;
	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float move = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Vertical");

        myAnim.SetFloat("speed", Mathf.Abs(move));

        myBody.velocity = new Vector2(move * maxSpeed,myBody.velocity.y);

        if (move > 0 && !facingRight )
        {
            flip();

        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        if(jump > 0)
        {
            if (grounded)
            {
 
                grounded = false;
                myBody.velocity = new Vector2(myBody.velocity.x, jumpheight);
                myAnim.SetBool("jump", true);
            }
        }
        else
        {
            myAnim.SetBool("jump", false);
        }


        if(Input.GetAxisRaw("Fire1") > 0)
        {
            fireBullet();
        }
	}

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {   
        switch(other.gameObject.tag) {
            case "Ground": grounded = true;
                break;
            case "vuc":
                Destroy(this.gameObject);
                
                break;
        }

    }

    //fire
    void fireBullet()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if(facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            } else if(!facingRight) {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
}
