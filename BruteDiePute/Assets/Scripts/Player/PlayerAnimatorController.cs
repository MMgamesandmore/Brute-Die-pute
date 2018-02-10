using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerAnimatorController : MonoBehaviour {

    public Animator anim;
    PlayerStats PlayerStats;
    public bool atk = false;
    // Use this for initialization
    void Start () {
        PlayerStats = FindObjectOfType<PlayerStats>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
       float vertical = Input.GetAxis("Vertical");


        if(anim.GetBool("atk Standard") == false && anim.GetInteger("SpecialAtk") == 0)
        {
            atk = false;
        }

        if (Input.GetButtonDown("Fire1") && atk == false)
        {
            
            anim.SetBool("is Walking", false);
            anim.SetBool("is idle", false);
            anim.SetBool("is Running", false);
            anim.SetBool("is Walking back", false);
            anim.SetBool("atk Standard", true);
            anim.SetInteger("SpecialAtk", 0);
            atk = true;
        }
        else if (Input.GetButtonDown("Fire2") && atk == false)
        {

            anim.SetBool("is Walking", false);
            anim.SetBool("is idle", false);
            anim.SetBool("is Running", false);
            anim.SetBool("is Walking back", false);
            anim.SetBool("atk Standard", false);
            anim.SetInteger("SpecialAtk", PlayerPrefs.GetInt("SpecialAtk"));
            atk = true;
        }
        else if(atk == false)
        {

            if (vertical > 0)
            {
                if (Input.GetKey(KeyCode.LeftShift) && PlayerStats.currentStamina > 2)
                {
                    anim.SetBool("is Walking", false);
                    anim.SetBool("is idle", false);
                    anim.SetBool("is Running", true);
                    anim.SetBool("is Walking back", false);
                    anim.SetBool("atk Standard", false);
                    anim.SetInteger("SpecialAtk", 0);
                }
                else {
                    anim.SetBool("is Walking", true);
                    anim.SetBool("is idle", false);
                    anim.SetBool("is Running", false);
                    anim.SetBool("is Walking back", false);
                    anim.SetBool("atk Standard", false);
                    anim.SetInteger("SpecialAtk", 0);
                }
            }

            if (vertical < 0)
            {
                anim.SetBool("is Walking", false);
                anim.SetBool("is idle", false);
                anim.SetBool("is Running", false);
                anim.SetBool("is Walking back", true);
                anim.SetBool("atk Standard", false);
                anim.SetInteger("SpecialAtk", 0);
            }

            if (vertical == 0)
            {
                anim.SetBool("is Walking", false);
                anim.SetBool("is idle", true);
                anim.SetBool("is Running", false);
                anim.SetBool("is Walking back", false);
                anim.SetBool("atk Standard", false);
                anim.SetInteger("SpecialAtk", 0);
            }
        }
        else
        {
            atk = false;
        }
    }
}
