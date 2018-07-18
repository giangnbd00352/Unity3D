using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {

    public GameObject Flash1;
    public GameObject Flash2;

    bool flicker = true;
    // Use this for initialization
    void Start () {
        StartCoroutine(FlashFlicker());
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator FlashFlicker()
    {
        yield return new WaitForSeconds(1f);
            //Debug.Log("Update" + Time.time);
        flicker = !flicker;
        Flash1.SetActive(flicker);
        StartCoroutine(FlashFlicker());

    }

}
