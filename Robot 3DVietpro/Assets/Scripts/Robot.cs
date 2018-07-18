using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot : MonoBehaviour {

    private Animator anim;
    private Rigidbody2D rigid;

    public GameObject Player;
    public Text getPoint;
    //toc do di chuyen robot
    public float Speed;
    public float MaxSpeed;
    //do cao khi nhay
    public float JumpSpeed;

    // dem so lan nhay
    int countJump = 0;
    int countPoint = 0;

    bool nextStatus;
    bool preStatus;


	// Use this for initialization
	void Start () {
        anim = Player.GetComponent<Animator>();
        rigid = Player.GetComponent<Rigidbody2D>();
        MaxSpeed = 3;
        JumpSpeed = 3000;
    }
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x+0.5f,transform.position.y), Vector2.right,0.2f);
        Debug.DrawRay(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.right, Color.red);
        RaycastHit2D hit1 = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 1.2f), Vector2.up, 0.5f);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + 1.2f), Vector2.up, Color.red);
        if (hit.collider != null)
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Dinamond")
            {
                Destroy(hit.transform.gameObject);
                countPoint++;
                getPoint.text = "Point:" + countPoint;
            }
        }
    }
    // Update is called once per frame
    void Update () {

       // float move = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.D))
        {
            Speed = MaxSpeed;
            Vector3 scale = Player.transform.localScale;
            scale.x = 1;
            Player.transform.localScale = scale;
            anim.SetInteger("Status", 1);
            nextStatus = true;
            AddForce(Speed);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Speed = 0;
            anim.SetInteger("Status", 0);
            nextStatus = false;
            AddForce(Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 scale = Player.transform.localScale;
            scale.x = -1;
            Player.transform.localScale = scale;

            Speed = -MaxSpeed;
            anim.SetInteger("Status", 1);
            preStatus = true;
            AddForce(Speed);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Speed = 0;
            anim.SetInteger("Status", 0);
            preStatus = false;
            AddForce(Speed);
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && Player.GetComponent<Collision>().Jumping == false)
        {
            Jump();
            MusicAllGame.Instance.PlayMusicGame(0);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetInteger("Status", 0);
        }
    }

    public void PreviousUp_Click()
    {
        preStatus = false;
        Speed = 0;
        anim.SetInteger("Status", 0);
    }

    public void PreviousDown_Click()
    {
        Debug.Log("Pre");
        preStatus = true;
        // Gan speed de robot di chuyen ve ben trai, truc x giam
        Speed = -MaxSpeed;

        //quay mat robot theo huong di chuyen ve ben trai
        Vector3 scale = Player.transform.localScale;
        scale.x = -1;
        Player.transform.localScale = scale;


        anim.SetInteger("Status", 1);
        AddForce(Speed);
    }

    public void NextUp_Click()
    {
        nextStatus = false;
        Speed = 0;
        anim.SetInteger("Status", 0);
    }

    public void NextDown_Click()
    {
        nextStatus = true;
        // Gan speed de robot di chuyen ve ben phai, truc x tang
        Speed = MaxSpeed;

        //quay mat robot theo huong di chuyen ve ben phai
        Vector3 scale = Player.transform.localScale;
        scale.x = 1;
        Player.transform.localScale = scale;

        anim.SetInteger("Status", 1);
        AddForce(Speed);
    }

    public void AUp_Click()
    {
        anim.SetInteger("Status", 0);
    }

    public void ADown_Click()
    {
        Jump();
        MusicAllGame.Instance.PlayMusicGame(0);
    }

    public void BUp_Click()
    {
        anim.SetInteger("Status", 0);
    }

    public void BDown_Click()
    {

        Vector3 scale = Player.transform.localScale;
        if (scale.x > 0)
        {
            Speed = MaxSpeed * 2;
        } else
        {
            Speed = -MaxSpeed * 2;
        }

        AddForce(Speed);
        anim.SetInteger("Status", 3);
    }

    public void AddForce(float speed)
    {
        Debug.Log(speed);
        rigid.velocity = new Vector3(speed, rigid.velocity.y, 0);
    }

    public void Jump()
    {
        if (Player.GetComponent<Collision>().Ground)
        {
            anim.SetInteger("Status", 2);
            rigid.AddForce(new Vector2(rigid.velocity.x, JumpSpeed));
            Player.GetComponent<Collision>().Jumping = true;
            Invoke("JumpDouble", 0.1f);
        }
        if (Player.GetComponent<Collision>().StatusJumpDouble)
        {
           
            countJump++;
            Debug.Log("countJump:" + countJump);
            anim.SetInteger("Status", 2);
            Player.GetComponent<Collision>().Jumping = true;
            rigid.AddForce(new Vector2(rigid.velocity.x, JumpSpeed));
            if (countJump == 2)
            {
                Player.GetComponent<Collision>().StatusJumpDouble = false;
                countJump = 0;
            }

        }
    }

    void JumpDouble()
    {
        Player.GetComponent<Collision>().StatusJumpDouble = true;
    }
}
