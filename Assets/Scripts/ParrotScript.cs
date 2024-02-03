using System;
using Unity.VisualScripting;
using UnityEngine;

public class ParrotScript : MonoBehaviour
{
    public Animator animator; //parrotAnimator
    public Rigidbody2D parrotBody;
    public Rigidbody2D dodoBody;
    public Dialogue parrotDialogue;
    public float previousValueOfRotation; //value for the rotation animation
    public double distance;


    void Start()
    {
        //Initialisation of components and parameters
        parrotBody = GetComponent<Rigidbody2D>();
        dodoBody=GetComponent<Rigidbody2D>();
        previousValueOfRotation=parrotBody.rotation;
        parrotDialogue=CreateParrotDialogue();
 
    }
    void Update()
    {
        previousValueOfRotation=SetAnimator(previousValueOfRotation); //Set the parrot animation
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            TriggerDialogue(); // If the player is close to the parrot and press P, the parrot's dialogue begin
        }
        distance = parrotBody.position.x -dodoBody.position.x;
        
    }
    public float SetAnimator(float _previousValueOfRotation)
    {
        bool rotate =false; //booleen that returns false if the parrot should not rotate, true if he rotates
        float valueOfActualRotation = parrotBody.rotation;
        //We look if the rotation of the parrot between -50 and 50 degree or if he does not rotates too fast
        if (Math.Abs(valueOfActualRotation)%360 >= 50 || Math.Abs(valueOfActualRotation)%360 >= 310 || Math.Abs(valueOfActualRotation - previousValueOfRotation) >10)
        {
            rotate=true; //we want the parrot animation with the stars
        }
        animator.SetBool("isHit", rotate); //we set the value of rotation to the animator
        return parrotBody.rotation;
    }
    public bool IsInRangeDialogue()
    { //function to know if the parrot is in range for the dialogue. He is in range if the euclidienne distance between the parrot and the dodo is below 3
        // A REVOIR
        if (Math.Sqrt(Math.Pow(parrotBody.position.x -dodoBody.position.x,2) + Math.Pow(parrotBody.position.y -dodoBody.position.y,2)) <1) 
        {
             return true;
        }
        return false;

    }
    private Dialogue CreateParrotDialogue()
    {
        //Initialisation of the parrot dialogue
        Dialogue dialogue = new Dialogue();
        dialogue.name= "Parrot";

        dialogue.lines = new DialogueLine[]
        {
            new DialogueLine("Croaaaa! Croaaaa!", false),
            new DialogueLine("Stop hiiiiiting me!", true, new Choice("I don't want...", new DialogueLine("Crroooaaaaaa !", false)), new Choice("My apologies",new DialogueLine("You're welllcome !", false))),            
        };

        return dialogue;
    }

    public void TriggerDialogue()
    { // if the player is close to the parrot and press P, the dialogue is trigger
        if ( IsInRangeDialogue()==true)
        {
            DialogueManager.instance.EndDialogue(); // close others dialogues
            DialogueManager.instance.ChangingDialogue(parrotDialogue); //use the parrot dialogue
            DialogueManager.instance.StartDialogue(); // start dialogue
        }
    }

}
