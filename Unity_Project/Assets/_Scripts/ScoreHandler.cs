using UnityEngine;
using System.Collections;

public class ScoreHandler : MonoBehaviour {

    private int score;
    private int brokenBonus = 3;
    private int baseTouch = 1;
    private int gggBonus = 1;
    private int unhorsedBonus = 10;
    private int headBonus = 7;
    private float baseBreakChance = 0.18f;
    private float speed;
    private float MaxSpeed = 45.0f;
    private bool brokenLance = false;
    private float randomChance;
    private float unhorseChance;


    public GameObject me;
    private NavMeshAgent agent;




    void Start ()
    {
        score = 0;
        agent = me.gameObject.GetComponent<NavMeshAgent>();
    }


    void OnTriggerEnter (Collider him)
    {
        speed = agent.speed;
        RandomRoll();

        if (him.tag == "Head")
        {
            score += (baseTouch + headBonus);
            //check for broken lance
            BrokenLanceChance(speed);
            //now check for unhorsing
            unhorseChance = 0.12f;
            if (brokenLance) unhorseChance = 0.85f;
            if (speed == MaxSpeed) unhorseChance += 0.1f;
            UnhorseChance(randomChance, unhorseChance);
        }
        if (him.tag == "Sweet")
        {
            score += (baseTouch + gggBonus);
            //check for broken lance
            BrokenLanceChance(speed);
            //now check for unhorsing
            if (speed < 35)
            {
                unhorseChance = 0.30f;
                if (brokenLance) unhorseChance += 0.08f;

            } else
            {
                unhorseChance = 0.95f;
                if (brokenLance) unhorseChance = 1.0f;
            }
            UnhorseChance(randomChance, unhorseChance);
        }
        if (him.tag == "Body")
        {
            score += baseTouch;
            //check for broken lance
            BrokenLanceChance(speed);
            //body shot can break a lance but no points awarded for it
            score -= brokenBonus;
        }
        if (him.tag == "GGG")
        {
            score += (baseTouch + gggBonus);
            //check for broken lance
            BrokenLanceChance(speed);
            //now check for unhorsing
            unhorseChance = 0.15f + (.05f * (MaxSpeed - speed));
            if (speed == MaxSpeed) unhorseChance = 0.4f;
            if (brokenLance) unhorseChance += 0.05f;
            UnhorseChance(randomChance, unhorseChance);
        }




    }








    // Helper Functions below this point

    void BrokenLanceChance (float speed)
    {
        float speedBonus = speed / 4.0f;
        if (speed == 50.0f) speedBonus += 0.1f;
    
        float totalBreakChance = speedBonus + baseBreakChance;
        float chanceRoll = Random.Range(0.0F, 1.0F);
        
        if (chanceRoll <= totalBreakChance)
        {
            score += brokenBonus;
            /*
                Here we have to somehow decide how to 
                animate the broken lance and RPC that 
                action to the other player as well as 
                play a sound for it

            */
            brokenLance = true;
        }

    }


    void UnhorseChance (float random, float chanceTot)
    {
        if (random <= chanceTot)
        {
            score += unhorsedBonus;
            /*
                Here we have to decide how to 
                RPC the opponent to know they've been unhorsed
                run the animations and sounds 
            */
            brokenLance = false;
        }


    }

    void UpdateScore()
    {
        //TBD

    }

    void RandomRoll ()
    {
        randomChance = Random.Range(0.0f, 1.0f);
    }



}
