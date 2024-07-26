using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSGmovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Animator BSGAnimator;
    [SerializeField] private BSGFlipper BSG;
    private Rigidbody2D rb;
    private bool canMove = true;
    private Vector2 movement; //Thanks Brackeys :) https://www.youtube.com/watch?v=whzomFgjT50
    private bool heIsMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    //Fixed Update is better than Update for physics
    //This is due to changes in framerate affecting the regular update function.
    private void FixedUpdate() 
    {

        //Rotation and animation
        if(movement.x < 0)
        {
            BSG.flipLeft();
        }
        else if (movement.x > 0)
        {
            BSG.flipRight();
        }

        //Is he moving? This is for animations.
        if(!canMove || (heIsMoving && movement.x == 0 && movement.y == 0) )
        {
            heIsMoving = false;
            BSGAnimator.SetBool("isMoving", false);
        }
        else if (canMove && !heIsMoving && (movement.x != 0 || movement.y != 0) )
        {
            heIsMoving = true;
            BSGAnimator.SetBool("isMoving", true);
        }

        //Movement
        //Moves the rigidbody to it's position + the added movement
        if (canMove)
        {
            rb.MovePosition(rb.position + (movement * speed * Time.fixedDeltaTime));
        }
        

    }

    public void freeze()
    {
        canMove = false;
    }

    public void thaw()
    {
        canMove = true;
    }
}
