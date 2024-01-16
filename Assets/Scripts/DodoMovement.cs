using TreeEditor;
using UnityEngine;

public class dodoMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public Rigidbody2D body;
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //At each frame, we reset the horizontal and vertical movements of the dodo
        float horizontalMovement = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        MoveDodo(horizontalMovement, verticalMovement);

    }
    void MoveDodo(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity =new Vector2(_horizontalMovement, _verticalMovement);
        body.velocity=Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, .05f);
    }
}
