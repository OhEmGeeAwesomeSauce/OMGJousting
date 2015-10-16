using UnityEngine;
using System.Collections.Generic;

public class AccelerateTrigger2 : MonoBehaviour {

    void OnTriggerEnter (Collider tag)
    {
        if(gameObject.tag == "Player")
        {
            JousterMove jm = gameObject.GetComponent <JousterMove> ();

            //   jm.spline = splines[1];
            jm.duration = jm.duration / 2;


                       
        }


    } 

}



