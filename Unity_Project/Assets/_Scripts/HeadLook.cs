using UnityEngine;
using System.Collections;

public class HeadLook : MonoBehaviour {

    /* 
       Gives the head camera for the jouster a more realistic frame for movement
       for looking around during the match. This mimics the standard mouse look
       script with additional contraints for the range of motion since a person's
       head can't actually swivel 360 degrees
    */

    //store inputs from mouse
    public float xRotate;
    public float yRotate;

    //store where player currently facing
    public float currentYrotate;
    public float currentXrotate;

    //store speed of the rotate
    public float xRotateVel;
    public float yRotateVel;

    //adjust the sensitivity of the input
    public float panSensitivity = 5.5f;

    //dampen the rotate for smoother motion
    public float dampen = 0.09f;



	void Update ()
    {
        //get input and inverts so up is up and down is down etc
        xRotate -= Input.GetAxis("Mouse Y") * panSensitivity * Time.deltaTime;
        yRotate -= Input.GetAxis("Mouse X") * panSensitivity * Time.deltaTime;

        //create the limited range of head motion from wearing helmet and armor
        xRotate = Mathf.Clamp(xRotate, -45, 45);
        yRotate = Mathf.Clamp(yRotate, -10, 50);

        //makes the actual rotations from input above
        currentXrotate = Mathf.SmoothDamp(currentYrotate, yRotate, ref yRotateVel, dampen * Time.deltaTime);
        currentYrotate = Mathf.SmoothDamp(currentXrotate, xRotate, ref xRotateVel, dampen * Time.deltaTime);
        transform.rotation = Quaternion.Euler(currentXrotate, currentYrotate, 0f);



    }
}
