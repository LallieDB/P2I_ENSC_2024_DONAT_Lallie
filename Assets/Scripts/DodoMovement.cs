using TreeEditor;
using UnityEngine;

public class dodoMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource dodoSound;
    public float moveSpeed;
    // public float jumpForce;
    public Rigidbody2D body;
    public Animator animator;
    private Vector3 velocity = Vector3.zero;

    private bool isShrieking;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //At each frame, we reset the horizontal and vertical movements of the dodo
        if(Input.GetButtonDown("Jump"))
        {
            isShrieking=true;
        }
        MoveDodo();
        SetAnimator();
    }
    void MoveDodo()
    {
        float horizontalMovement = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        Vector3 targetVelocity =new Vector2(horizontalMovement, verticalMovement);
        body.velocity=Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, .05f);
        if (isShrieking==true)
        {
            dodoSound.Play();
            isShrieking=false;
        }
    }
    void SetAnimator()
    {
        animator.SetFloat("HorizontalSpeed",body.velocity.x);
        animator.SetFloat("VerticalSpeed",body.velocity.y);

    }
}
