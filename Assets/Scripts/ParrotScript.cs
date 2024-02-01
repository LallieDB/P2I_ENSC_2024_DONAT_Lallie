using System;
using Unity.VisualScripting;
using UnityEngine;

public class ParrotScript : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D parrotBody;
    public Rigidbody2D dodoBody;
    public Dialogue parrotDialogue;
    public float previousValueOfRotation;
    // public bool isDialogueTrigger;

    void Start()
    {
        parrotBody = GetComponent<Rigidbody2D>();
        previousValueOfRotation=parrotBody.rotation;
        parrotDialogue=CreateParrotDialogue();
        // isDialogueTrigger=false;
    }
    void Update()
    {
        //At each frame, we reinitialize the animation of the parrot
        previousValueOfRotation=SetAnimator(previousValueOfRotation);
        if( Input.GetKeyDown(KeyCode.P))
        {
            TriggerDialogue();
        }
    }
    public float SetAnimator(float _previousValueOfRotation)
    {
        bool rotate =false; //booleen that returns false if the parrot should not rotate, true if he rotates
        float valueOfActualRotation = parrotBody.rotation;
        //We look if the rotation of the parrot between -50 and 50 degree or if he does not rotates too fast
        if (Math.Abs(valueOfActualRotation)%360 >= 50 || Math.Abs(valueOfActualRotation)%360 >= 310 || Math.Abs(valueOfActualRotation - previousValueOfRotation) >10)
        {
            rotate=true; //in this case, the parrot rotates
        }
        animator.SetBool("isHit", rotate); //we set the value of rotation to the animator
        return parrotBody.rotation;
    }
    public bool IsInRangeDialogue()
    {
        if (Math.Sqrt(Math.Pow(parrotBody.position.x -dodoBody.position.x,2) + Math.Pow(parrotBody.position.y -dodoBody.position.y,2)) <3) 
        {
             return true;
        }
        return false;

    }
    private Dialogue CreateParrotDialogue()
    {
        //The parrot dialogue
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
    {
        if (IsInRangeDialogue()==true)
        {
            DialogueManager.instance.EndDialogue();
            DialogueManager.instance.ChangingDialogue(parrotDialogue); 
            DialogueManager.instance.StartDialogue();
        }
        // isDialogueTrigger=true;
    }

}
