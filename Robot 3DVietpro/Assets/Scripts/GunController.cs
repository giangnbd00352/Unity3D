using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    //public GameObject Dan;
    public Transform BulletPosition;

    float StartTime;
    float StartGun;
    float midTime;
    float midGunTime;
    float getTime;

    bool blDan;
    bool StatusQuay;
    bool StatusBan;

    Rigidbody2D rg;
    int dem;
	// Use this for initialization
	void Start () {
        //Khai báo khởi tạo thời gian
        StartTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        //Biến MidTime lấy khoảng thời gian đang chạy so với thời gian ban đầu
        midTime = Time.time - StartTime;
        //Nếu midTime mà nhỏ hơn 1s thì ta thực hiện thiết lập StatusQuay = false tức là tiếp tục quay,
        // và giá trị thời gian liên tục gắn vào getTime
        if (midTime < 1f)
        {
            StatusQuay = false;
            getTime = Time.time;
        }
        else //Nếu thời gian mà lớn hơn 1s thì thực hiện
        {
            //Khi nhảy sang else thì ta có getTime cuối cùng, và lấy thời gian hiện tại - đi getTime,
            //nếu nhỏ hơn 1 thì bật trạng thái quay
            if (Time.time - getTime < 1)
            {
                StatusQuay = true;
            } //nếu >1 thì reset lại StartTime
            else
            {
                StartTime = Time.time;
            }
        }
        //thực hiện quay xung quanh chiều z với vận tốc 30 * time.detatime
        if (StatusQuay == true)
        {
            dem = 0;
            transform.Rotate(new Vector3(0, 0, 1), 30 * Time.deltaTime);

            //biến StartGun lấy dùng mục đích lấy giá trị thời gian cuối cùng
            //khi dừng để thực hiện bắn đạn 3 phát
            StartGun = Time.time;
        }
        else
        {
            //Biến midGunTime lấy thời gian chạy khi bắt đầu dừng súng để bắn
            midGunTime = Time.time - StartGun;
            //Debug.Log("StartGun: " + StartGun);
            //quy định số lần bắn
            if (dem < 3)
            {
                //float ct =
                //Nếu midGunTime > 0.3f thì thực hiện bắn
                //Lưu ý thời gian dừng là 1s, chúng ta quy định 0.3 tức là bắn 1 lần, và bắn 3 quả trong 1s
                if(midGunTime > 0.3f)
                {
                    //Sinh đạn và đẩy lực
                    GameObject NewRG;
                    NewRG = Instantiate(BulletPosition.GetChild(0).gameObject, BulletPosition.transform.position, BulletPosition.transform.rotation) as GameObject;
                    NewRG.SetActive(true);
                    NewRG.transform.tag = "Ball";
                    rg = NewRG.GetComponent<Rigidbody2D>();
                    rg.AddForce(-BulletPosition.transform.up * 300);
                    //Cộng thêm thời gian cho StartGun sau mỗi lần bắn
                    StartGun += 0.3f;
                    dem++;
                }
            }
        }    
	}
}
