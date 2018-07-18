using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Collision : MonoBehaviour {

    public bool Ground;
    public bool StatusJumpDouble = false;
    public bool Jumping;
    public Slider SlideHealth;

    [SerializeField]
    LayerMask whatIsGround;
    public Transform groundCheck;
    bool grounded = false;
    public float groundedRadius = 0.3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ground = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        if (Ground)
        {
            //Debug.Log("** Va Cham OverlapCircle");
            StatusJumpDouble = false;
            Jumping = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.transform.name);
        if (collision.gameObject.tag == "Ball")
        {
           //Debug.Log("Va Cham Bong");
            Destroy(collision.gameObject);
            SlideHealth.value -= 0.2f;
            if(SlideHealth.value<=0)
            {
               // Debug.Log("OverGame");
                Destroy(collision.gameObject);
            }
        }
    }
}
