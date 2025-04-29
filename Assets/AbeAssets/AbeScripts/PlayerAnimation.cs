using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //This script will be the "Glue" between PLayground Scripts and our own animation.
    //These first components exist so that we obtain the information necessary from PLayground scripts
    Animator animator;
    Move move;
    Jump jump;
    ObjectShooter shooter;

    // Start is called before the first frame update
    void Start()
    {
        //Go get the animator component
        animator = GetComponent<Animator>();

        //Check if we have a Playground "Move" script. If we do, get it. If not, send an error to the console
        if (GetComponent<Move>() != null)
        {
            move = GetComponent<Move>();
        }
        else
        {
            Debug.Log("I don't have a MOVE script!");
        }

        //Check if we have a Playground "Jump" script. If we do, get it. If not, send an error to the console
        if (GetComponent<Jump>() != null)
        {
            jump = GetComponent<Jump>();
        }
        else
        {
            Debug.Log("I don't have a JUMP script!");
        }

        //Check if we have a Playground "Object Shooter" script in a child object (a gun). If we do, get it. If not, send an error to the console
        if (GetComponentInChildren<ObjectShooter>() != null)
        {
            shooter = GetComponentInChildren<ObjectShooter>();
        }
        else
        {
            Debug.Log("I don't have a GUN script!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //This code takes the value "moveHorizontal" from the Playground's "Move" script and uses it to activate the run animation
        //IMPORTANT: for this to work, change Playground's "moveHorizontal" float from private to public (line 22 in the "Move" script)
        //IMPORTANT: if the Animation Controller does not have a transition parameter called "animSpeed", this won't work
        animator.SetFloat("animSpeed", Mathf.Abs(move.moveHorizontal));

        //This is the code to make the player jump. 
        //IMPORTANT: for this to work, we need to add a new public boolean in Playground's "Jump" called "isJumping" (line 25 in Playground's "Jump")
        //then, you need to set this "isJumping" to true when the player jumps (line 38 in Playground's "Jump")
        //and finally set it back to false when the player is not jumping (line 50 in Playground's "Jump")
        if (jump.isJumping)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}
