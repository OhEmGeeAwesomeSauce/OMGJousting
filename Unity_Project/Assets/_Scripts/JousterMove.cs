using UnityEngine;


public class JousterMove : MonoBehaviour {
    /* The purpose of this script is to create an object to traverse the list
       which of course is the horse.
     */


    /*
        Adam Note: list of Splines can now be used. Pull prefab splines into it.
        Then create a conditional, and a round variable. The round is the number 
        of tilts in the joust. The list for Player1 should have spline1 first
        spline 2 second. Player 2 is reversed. The conditional should just 
        alternate, so when round is odd players reference the first element
        of their spline list, and then the second. This should create the utility
        to have them alternate splines automatically.
    */




    public BezierSpline spline;
    public float duration;
    public bool lookForward;
    public JousterMoveMode mode;

    private float progress;
    private bool goingForward = true;


    public enum JousterMoveMode
    {
        Once,
        Loop,
        PingPong
    }

	
	void Update () {

        if (goingForward)
        {
            progress += Time.deltaTime / duration;
            if (progress > 1f) {

                if (mode == JousterMoveMode.Once)
                {
                    progress = 1f;

                } else if (mode == JousterMoveMode.Loop)
                {
                    progress -= 1f;

                } else
                {
                    progress = 2f - progress;
                    goingForward = false;
                }
            }
        } else
        {
            progress -= Time.deltaTime / duration;
            if (progress < 0f)
            {
                progress = -progress;
                goingForward = true;
            }
        }

        Vector3 position = spline.GetPoint(progress);
        transform.localPosition = position;
        if (lookForward)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
	}
}
