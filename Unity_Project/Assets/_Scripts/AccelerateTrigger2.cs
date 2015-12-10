using UnityEngine;
using System.Collections;

public class AccelerateTrigger2 : MonoBehaviour
{

    public GameObject player;

    private NavMeshAgent agent;

    private bool canSpeedUp = false;
    private bool canSlowDwn = false;


    void Start()
    {
        agent = player.gameObject.GetComponent<NavMeshAgent>();
    } 


    void OnTriggerEnter (Collider other)
    {

        if (other.tag == "Decel")
        {
            canSlowDwn = true;
        }
        if (other.tag == "Accel")
        {
            canSpeedUp = true;
        }

    }


    void OnTriggerExit (Collider other)
    {

        canSpeedUp = false;
        canSlowDwn = false;
    }

    void Update ()
    {

        if (canSpeedUp)
        {
            if (Input.GetKeyDown("space"))
            {
                agent.speed = agent.speed + 5f;
                canSpeedUp = false;
            }
            
        }
        if (canSlowDwn)
        {
            if (Input.GetKeyDown("space") && agent.speed > 3f)
            {
                agent.speed = agent.speed - 3f;
            }
        }

    }





    //void OnTriggerStay(Collider col)
    //{

    //    if (Input.GetKeyDown("space"))
    //    {
    //        gameObject.GetComponent<NavMeshAgent>().speed += 5f;
    //        //col.GetComponent<NavMeshAgent>().speed += 5;

    //    }

    //}







}



