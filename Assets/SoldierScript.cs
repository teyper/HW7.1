using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour
{
//create ani referenece 
    Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent < SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //walk up
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //runs when up arrow is presssed
            animator.SetBool("WalkUp", true);
        }
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            //runs when up arrow is released
            animator.SetBool("WalkUp", false);
        }

        //walk down
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            //runs when up arrow is presssed
            animator.SetBool("WalkDown", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //runs when up arrow is released
            animator.SetBool("WalkDown", false);
        }
        //walk right 
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //runs when up arrow is presssed
            animator.SetBool("WalkRight", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //runs when up arrow is released
            animator.SetBool("WalkRight", false);
        }

        //walk left 
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //runs when up arrow is presssed
            animator.SetBool("WalkRight", true);
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //runs when up arrow is released
            animator.SetBool("WalkRight", false);
            spriteRenderer.flipX = false;
        }
    }
}
