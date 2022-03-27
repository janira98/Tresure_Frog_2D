using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rBody;
    private Animator mator;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private float dirX = 0;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float runningSpeed = 10;

    private enum MovementState { idle, running, jumping, falling }
    
    // Start is called before the first frame update
    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        mator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rBody.velocity = new Vector2(dirX * runningSpeed, rBody.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSound.Play();
            rBody.velocity = new Vector2(rBody.velocity.x,jumpForce);
        }

        CharactorAnimationUpdate();
    }

    private void CharactorAnimationUpdate()
    {
        MovementState state;

        if (dirX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rBody.velocity.y > .1)
        {
            state = MovementState.jumping;
        }
        else if (rBody.velocity.y < -.1)
        {
            state = MovementState.falling;
        }

        mator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
