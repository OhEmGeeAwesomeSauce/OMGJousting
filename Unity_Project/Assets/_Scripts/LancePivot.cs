using UnityEngine;
using System.Collections;

public class LancePivot : MonoBehaviour {

    /* 
        Creates a customized pivot point. 
        Used to simulate the rotation and aiming
        of the player's lance from where the 
        lance would be held.
    */

        public float size = 1.0f;
        public Color color = Color.yellow;

        void OnDrawGizmos ()
        {
            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, size);

        }

	
}
