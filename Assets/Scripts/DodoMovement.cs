using TreeEditor;
using UnityEngine;

public class dodoMovement : MonoBehaviour
{
    public AudioSource dodoSound;
    public Rigidbody2D body;
    public Animator animator;
    public Item intialEggs;
    private Inventory inventory;
    private Vector3 velocity = Vector3.zero;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {   //at the start of the game, we add eggs to the dodo inventory
        inventory = FindObjectOfType<Inventory>();
        inventory.AddItem(intialEggs);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) //If the player press F, play the dodo sound
        {
            dodoSound.Play();
        }
        MoveDodo(); //Reset the horizontal and vertical movements of the dodo
        SetAnimator(); //Set the appropriate animation for the dodo

        //if the player press O and he has an egg in is inventory, he eats one egg and gains speed
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventory.IsItemInInventory(intialEggs))
            {
                inventory.FindAndPickItem(intialEggs);
                moveSpeed = moveSpeed * 1.2f;
            }
        }
    }

    void MoveDodo()
    {
        //Set the vertical and horizontal movements
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector3 targetVelocity = new Vector2(horizontalMovement, verticalMovement);
        //Make the transition with the current dodo's velocity
        body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref velocity, .05f);
    }

    void SetAnimator()
    {
        //Give the horizontal and vertical velocity to the animator
        animator.SetFloat("HorizontalSpeed", body.velocity.x);
        animator.SetFloat("VerticalSpeed", body.velocity.y);
    }
}
