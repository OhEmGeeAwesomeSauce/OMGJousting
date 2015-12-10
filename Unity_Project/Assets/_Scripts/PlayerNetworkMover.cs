﻿using UnityEngine;
using System.Collections;

public class PlayerNetworkMover : Photon.MonoBehaviour {


    Vector3 position;
    Quaternion rotation;
    float smoothing = 10f;


    void Start()
    {

        if (photonView.isMine)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<NavAgent>().enabled = true;
            GetComponent<AccelerateTrigger2>().enabled = true;
            GetComponentInChildren<LanceFollow>().enabled = true;

            GetComponent<NavMeshAgent>().enabled = true;
            GetComponentInChildren<HeadLook>().enabled = true;
            GetComponentInChildren<LanceController>().enabled = true;
            GetComponentInChildren<LanceFollow>().enabled = true;

            foreach (Camera cam in GetComponentsInChildren<Camera>())
                cam.enabled = true;
        }
        else
        {
            StartCoroutine("UpdateData");
        }
    }

    IEnumerator UpdateData()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * smoothing);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * smoothing);
            yield return null;
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            position = (Vector3)stream.ReceiveNext();
            rotation = (Quaternion)stream.ReceiveNext();
        }
    }


}
