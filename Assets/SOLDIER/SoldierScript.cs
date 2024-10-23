using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour
{
    [SerializeField] float Speed = 2f;
    [SerializeField] float Ymin = -4f; // lower boundary 
    [SerializeField] float Ymax = 4f; //upper boundary
    [SerializeField] float Xmin = -6.5f;
    [SerializeField] float Xmax = 6.5f;
    [SerializeField] GameObject laserPrefab; //bullet
    //create ani referenece 
    Animator animator;
    SpriteRenderer spriteRenderer;

    //laser direction
    private Vector3 laserDirection = Vector3.up;
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
            laserDirection = Vector3.up;
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
            laserDirection = Vector3.down;
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
            laserDirection = Vector3.right;
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
            laserDirection = Vector3.left;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //runs when up arrow is released
            animator.SetBool("WalkRight", false);
            spriteRenderer.flipX = false;
        }

        //transforming the little guy

        float y;
        float x;


        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");


        transform.Translate(0f, y * Speed * Time.deltaTime, 0f);
        transform.Translate(x * Speed * Time.deltaTime, 0f, 0f);

        // boundary above Ymax
        if (transform.position.y > Ymax)
        {
            transform.position = new Vector3(transform.position.x, Ymax, transform.position.z);
        }
        //boundary below Ymin
        if (transform.position.y < Ymin)
        {
            transform.position = new Vector3(transform.position.x, Ymin, transform.position.z);
        }
        // boundary outside Xmax
        if (transform.position.x > Xmax)
        {
            transform.position = new Vector3(Xmax, transform.position.y, transform.position.z);
        }
        //boundary outside Xmin
        if (transform.position.x < Xmin)
        {
            transform.position = new Vector3(Xmin, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))  // instatiate rasengan
        {
            GameObject obj;
            obj = Instantiate(laserPrefab);
            //move laser to gun
            obj.transform.position = transform.position;
            Rigidbody2D rigidBody = obj.GetComponent<Rigidbody2D>();
            rigidBody.velocity = laserDirection * 10f;
            // obj.transform.Translate(rasengy_x_offset, rasengy_y_offset, 0f);

        }
    }
}
