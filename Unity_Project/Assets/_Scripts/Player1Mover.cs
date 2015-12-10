using UnityEngine;
using System.Collections;

public class Player1Mover : MonoBehaviour {

    public float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player_1_end_list").transform.position, moveSpeed * Time.deltaTime);
    }
}
