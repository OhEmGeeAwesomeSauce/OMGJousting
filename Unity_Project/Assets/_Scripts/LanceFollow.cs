using UnityEngine;
using System.Collections;
using WiimoteApi.Util;
using WiimoteApi;

public class LanceFollow : MonoBehaviour
{
    public int _resolution_x;
    public int _resolution_y;

    private float distance;

    private Camera camera;

    //private Wiimote wiimote;

    // Use this for initialization
    void Start()
    {
        camera = GameObject.Find("PlayerHeadLook").GetComponent<Camera>();
        Vector3 camToBall = GameObject.Find("PlayerHeadLook").transform.position - transform.position;

        //Vector3 camToBall = transform.parent.FindChild("PlayerHeadLook").position - transform.position;
        distance = camToBall.magnitude;
        //WiimoteManager.FindWiimotes();
    }

    // Update is called once per frame
    void Update()
    {
        // GUI.
        //True if a wiimote is connected
        //if (wiimote != null)
        //if (WiimoteManager.HasWiimote())
        //{
        //    // GUILayout.Label("Wiimote Connected");
        //    //Sets up the Ir Camera in the wiimote
        //    wiimote.SetupIRCamera(IRDataType.BASIC);
        //    //Gets x and y midpoint between 0 and 1
        //    float[] wiiPosition = wiimote.Ir.GetIRMidpoint();
        //    Vector3 myWiimote;
        //    myWiimote.x = (int)(wiiPosition[0] * _resolution_x);
        //    myWiimote.y = (int)(wiiPosition[1] * _resolution_y);
        //    Debug.Log(myWiimote.x + " " + myWiimote.y);
        //    myWiimote.z = distance;

        //    transform.position = camera.ScreenToWorldPoint(myWiimote);
        //}
        //Use mouse by default
        //else
        {
            // GUILayout.Label("Wiimote not Connected");
            //WiimoteManager.FindWiimotes();
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = distance;
            transform.position = camera.ScreenToWorldPoint(mousePosition);
        }
    }
}
