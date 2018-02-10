using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 1;
    public float runSpeed = 2;
    public float rotateSpeed = 100;
    float horizontal;
    float vertical;
    PlayerStats PlayerStats;
    PlayerAnimatorController PlayerAnimatorController;
    public float minusStaminaSpeed = 0.2f;
    // Use this for initialization
    void Start () {
        PlayerStats = FindObjectOfType<PlayerStats>();
        PlayerAnimatorController = FindObjectOfType<PlayerAnimatorController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


            //rotation
        if (horizontal > 0)
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        if (horizontal < 0)
        {
            transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        }
        //Movement
        if (PlayerAnimatorController.atk == false)
        {
            if (vertical < 0)
            {
                transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
            }
            if (vertical > 0)
            {
                if (Input.GetKey(KeyCode.LeftShift) && PlayerStats.currentStamina > 0)
                {
                    transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
                    PlayerStats.currentStamina -= minusStaminaSpeed;
                }
                else
                {
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                }

            }
        }
    }
}
