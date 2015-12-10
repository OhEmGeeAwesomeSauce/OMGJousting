using UnityEngine;
using System.Collections;

public class iAmStruck : MonoBehaviour {

    public GameObject player;
    private float speed;
    private float breakChance;
    private float unhorseChance;

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Lance")
        {
            if (player.tag == "Head")
            {



            }
            if (player.tag == "Sweet")
            {




            }
            if (player.tag == "GGG")
            {



            }
            if (player.tag == "Body")
            {




            }

        }

    }


}
