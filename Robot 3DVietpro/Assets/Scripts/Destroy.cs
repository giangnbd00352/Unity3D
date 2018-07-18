using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {


    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        //Debug.Log("Va cham");
        if(collision.gameObject.tag=="ground")
        {
            //Debug.Log("Destroy");
            Destroy(gameObject,1f);
        }
    }
}
