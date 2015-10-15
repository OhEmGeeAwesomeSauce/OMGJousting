using UnityEngine;
using System.Collections;

public class LanceController : MonoBehaviour {

    public float speed = 5f;


	
	
	void FixedUpdate () {

        float moveH = Input.GetAxis("Horizontal");

        float moveV = Input.GetAxis("Vertical");

        moveH = Mathf.Clamp(moveH, -10, 10);
        moveV = Mathf.Clamp(moveV, -45, 45);


        transform.Rotate(moveV * speed * Time.deltaTime, moveH * speed * Time.deltaTime, 0);

	}
}
