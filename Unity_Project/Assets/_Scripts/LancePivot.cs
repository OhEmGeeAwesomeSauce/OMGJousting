using UnityEngine;
using System.Collections;

public class LancePivot : MonoBehaviour {

    /* 
        Creates a customized pivot point. 
        Used to simulate the rotation and aiming
        of the player's lance from where the 
        lance would be held.
    */
    private GameObject lance;
    private GameObject lancePivot;

    private float rotateValue = 0;
    private Vector3 pivotVector;
     

    void Start()
    {
        lance = GameObject.Find("Lance");
        lancePivot = GameObject.Find("LancePivot");

        pivotVector.x = lancePivot.transform.position.x;
        pivotVector.y = lancePivot.transform.position.y;
        pivotVector.z = lancePivot.transform.position.z;

    }

    void Update()
    {
        this.transform.RotateAround(pivotVector, Vector3.right, rotateValue);
        this.transform.RotateAround(pivotVector, Vector3.up, rotateValue);
        this.transform.RotateAround(pivotVector, Vector3.down, rotateValue);


    }

}
