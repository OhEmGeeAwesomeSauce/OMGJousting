using UnityEngine;
using System.Collections;

public class Player2Mover : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player_2_end_list").transform.position, moveSpeed * Time.deltaTime);
    }
}
