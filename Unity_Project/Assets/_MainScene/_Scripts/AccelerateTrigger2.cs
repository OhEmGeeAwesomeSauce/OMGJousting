using UnityEngine;
using System.Collections;

public class AccelerateTrigger2 : MonoBehaviour
{

    public GameObject player;

    private NavMeshAgent agent;

    private bool canSpeedUp = false;
    private bool canSlowDwn = false;

    public float speed = 5f;
    public float slow = 3f;

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
                agent.speed = agent.speed + speed;
                canSpeedUp = false;
            }
            
        }
        if (canSlowDwn)
        {
            if (Input.GetKeyDown("space") && agent.speed > slow)
            {
                agent.speed = agent.speed - slow;
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



