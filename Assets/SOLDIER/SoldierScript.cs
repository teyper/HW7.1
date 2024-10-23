using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour
{
    [SerializeField] float Speed = 2f;
    [SerializeField] float Ymin = -4f; // lower boundary 
    [SerializeField] float Ymax = 4f; // upper boundary
    [SerializeField] float Xmin = -6.5f;
    [SerializeField] float Xmax = 6.5f;
    [SerializeField] GameObject laserPrefab; // bullet
    // Create animator reference 
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Laser direction
    private Vector3 laserDirection = Vector3.down;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Horizontal movement and flipping logic
        if (x > 0) // Moving right
        {
            animator.SetBool("WalkRight", true);
            spriteRenderer.flipX = false; // Don't flip when moving right
            laserDirection = Vector3.right;
        }
        else if (x < 0) // Moving left
        {
            animator.SetBool("WalkRight", true);
            spriteRenderer.flipX = true; // Flip when moving left
            laserDirection = Vector3.left;
        }
        else
        {
            animator.SetBool("WalkRight", false); // Stop horizontal movement animation
        }

        // Vertical movement logic
        if (y > 0) // Moving up
        {
            animator.SetBool("WalkUp", true);
            laserDirection = Vector3.up;
        }
        else if (y < 0) // Moving down
        {
            animator.SetBool("WalkDown", true);
            laserDirection = Vector3.down;
        }
        else
        {
            animator.SetBool("WalkUp", false); // Stop vertical movement animation
            animator.SetBool("WalkDown", false); // Stop vertical movement animation
        }

        // Move the player
        transform.Translate(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime, 0f);

        // Boundary enforcement
        if (transform.position.y > Ymax) transform.position = new Vector3(transform.position.x, Ymax, transform.position.z);
        if (transform.position.y < Ymin) transform.position = new Vector3(transform.position.x, Ymin, transform.position.z);
        if (transform.position.x > Xmax) transform.position = new Vector3(Xmax, transform.position.y, transform.position.z);
        if (transform.position.x < Xmin) transform.position = new Vector3(Xmin, transform.position.y, transform.position.z);
    


if (Input.GetKeyDown(KeyCode.Space))  // instatiate laser
        {
            GameObject obj;
            obj = Instantiate(laserPrefab);
            //move laser to gun
            obj.transform.position = transform.position;
            //laser rotation

            if(laserDirection == Vector3.up)
            {
                obj.transform.Rotate(0f, 0f, 90f);
            }
            if (laserDirection == Vector3.down)
            {
                obj.transform.Rotate(0f, 0f, -90f);
            }

            Rigidbody2D rigidBody = obj.GetComponent<Rigidbody2D>();
            rigidBody.velocity = laserDirection * 10f;
            // obj.transform.Translate(rasengy_x_offset, rasengy_y_offset, 0f);

        }
    }
}
