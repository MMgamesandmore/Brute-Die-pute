using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAtkController : MonoBehaviour {

    public int SpecialAtk = 1;
    public int maxSpecialAtk = 2;


    public GameObject SpecialImage1;
    public GameObject SpecialImage2;


    public void plusSpecialAtk()
    {
        SpecialAtk += 1;
    }
    public void minusSpecialAtk()
    {
        SpecialAtk -= 1;
    }
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        PlayerPrefs.SetInt("SpecialAtk", SpecialAtk);

        if(SpecialAtk == 0)
        {
            SpecialAtk = maxSpecialAtk;
        }
        if (SpecialAtk > maxSpecialAtk)
        {
            SpecialAtk = 1;
        }
        //Input
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpecialAtk = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpecialAtk = 2;
        }
        // Image zuweisung
        if(PlayerPrefs.GetInt("SpecialAtk") == 1)
        {
            SpecialImage1.SetActive(true);
            SpecialImage2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("SpecialAtk") == 2)
        {
            SpecialImage2.SetActive(true);
            SpecialImage1.SetActive(false);
        }
    }
}
