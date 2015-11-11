using UnityEngine;
using System.Collections;

public class LanceFollow : MonoBehaviour {

    public float distance = 2.0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePostion = Input.mousePosition;
        mousePostion.z = distance;
        transform.position = Camera.main.ScreenToWorldPoint(mousePostion);
    }
}
