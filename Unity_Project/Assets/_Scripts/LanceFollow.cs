using UnityEngine;
using System.Collections;

public class LanceFollow : MonoBehaviour {

    private float distance;

    private Camera camera;

    // Use this for initialization
    void Start()
    {
        camera = GameObject.Find("PlayerHeadLook").GetComponent<Camera>();
        Vector3 camToBall = GameObject.Find("PlayerHeadLook").transform.position - transform.position;

        //Vector3 camToBall = transform.parent.FindChild("PlayerHeadLook").position - transform.position;
        distance = camToBall.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePostion = Input.mousePosition;
        mousePostion.z = distance;
        transform.position = camera.ScreenToWorldPoint(mousePostion);
    }
}
