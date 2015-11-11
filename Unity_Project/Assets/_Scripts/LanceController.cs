using UnityEngine;
using System.Collections;

public class LanceController : MonoBehaviour {

    public Transform target;

    private float actualDistance;

    void Start()
    {
        Vector3 toObjectVector = transform.position - Camera.main.transform.position;
        Vector3 linearDistanceVector = Vector3.Project(toObjectVector, Camera.main.transform.forward);
        actualDistance = linearDistanceVector.magnitude;
    }
    void FixedUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = actualDistance;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        //Vector3 relativePosition = target.position - transform.position;
        //transform.rotation = Quaternion.LookRotation(relativePosition);
    }

    /* public float turnSpeed = 5.0f;
     bool flag = true;*/

    /*private Vector3 lanceInitPosition;
    private Vector3 mouseInitPosition;
    private Vector3 mouseVector;
    
    void Start()
    {
        lanceInitPosition = transform.localPosition;
        mouseInitPosition = new Vector3(1366/2, 768/2, 0);
    }

    void FixedUpdate() {
        mouseVector = (Input.mousePosition - mouseInitPosition);
        transform.position = Camera.current.ScreenToWorldPoint(mouseVector);
        Debug.Log("mouseVector"+mouseVector+"lancePosition:"+lanceInitPosition);*/
        
        //My Screen is 1366 x 768
        /*float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        mouseY = Mathf.Clamp(mouseY, 0, 768);
        mouseX = Mathf.Clamp(mouseX, 0, 1366);
        Vector3 perpPlayer = new Vector3(-1, 0, 1);
        
        if (Input.GetMouseButtonDown(0) &&flag)
        {
            Vector3 v3Current = new Vector3(45,0,0);
            v3Current = transform.eulerAngles + v3Current;
            transform.eulerAngles = v3Current;
            flag = false;
        }*/
        
        /*if (mouseX > 1366 / 2)
        {
            transform.rotation;
        }
        else
        {
            transform.Rotate(perpPlayer, -10 * Time.deltaTime);
        }
        if (mouseY > 768 / 2)
        {
            transform.Rotate(Vector3.up, 10 * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.up, -10 * Time.deltaTime);
        }*/


        /* Vector3 addParentPosition = new Vector3(-10, 0, 10);
         //Creates a ray perpendicular to the way the player points. Used to rotate around
         Ray playerForward = new Ray(transform.parent.position, transform.parent.position + addParentPosition);*/

        //var head = transform.parent.FindChild("Head");

        //rotates lance around character???
        /*float mouseX = Input.GetAxis("Mouse X"); //get x
        float mouseY = Input.GetAxis("Mouse Y"); //get y
        Vector3 movementVector = new Vector3(mouseY, mouseX, 0); //Perhaps arrange your values into a Vector3 if you're multiplying by the same sensitivity?
        transform.Rotate(movementVector * turnSpeed);*/

        //adams code
        /*float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        moveH = Mathf.Clamp(moveH, -10, 10);
        moveV = Mathf.Clamp(moveV, -45, 45);
        transform.Rotate(moveV * speed * Time.deltaTime, moveH * speed * Time.deltaTime, 0);*/

    
}
