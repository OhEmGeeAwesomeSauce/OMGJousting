using UnityEngine;
using System.Collections;

public class NavAgent : MonoBehaviour {

    public Transform target;
    private NavMeshAgent rider;



	// Use this for initialization
	void Start ()
    {

        rider = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update ()
    {

        rider.SetDestination(target.position);

	}
}
