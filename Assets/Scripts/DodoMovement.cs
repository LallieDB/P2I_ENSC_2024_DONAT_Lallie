using TreeEditor;
using UnityEngine;

public class dodoMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    // public float jumpForce;
    public Rigidbody2D body;
    public Animator animator;
    private Vector3 velocity = Vector3.zero;

    // private bool isJumping;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //At each frame, we reset the horizontal and vertical movements of the dodo
        float horizontalMovement = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        // if(Input.GetButtonDown("Jump"))
        // {
        //     isJumping=true;
        // }

        MoveDodo(horizontalMovement, verticalMovement);
        SetAnimator();
    }
    void MoveDodo(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity =new Vector2(_horizontalMovement, _verticalMovement);
        body.velocity=Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, .05f);
        // if (isJumping==true)
        // {
        //     body.AddForce(new Vector2(0f,jumpForce));
        //     isJumping=false;
        // }
    }
    void SetAnimator()
    {
        animator.SetFloat("HorizontalSpeed",body.velocity.x);
        animator.SetFloat("VerticalSpeed",body.velocity.y);

    }
}
