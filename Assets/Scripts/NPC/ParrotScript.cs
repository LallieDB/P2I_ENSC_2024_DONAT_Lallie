using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ParrotScript : MonoBehaviour
{
    private GameObject interactionDialogue;
    public Animator animator; //parrotAnimator
    public Rigidbody2D parrotBody;
    public Rigidbody2D dodoBody;
    public Dialogue normalDialogue;
    public Dialogue isHitDialogue;
    public bool isInRange;
    public bool isHit; //keep in memory if the dodo has hit the parrot. If the dodo apologize, reinitialize at zero
    public float previousValueOfRotation; //value for the rotation animation

    void Start()
    {
        //Initialisation of components and parameters
        parrotBody = GetComponent<Rigidbody2D>();
        previousValueOfRotation=parrotBody.rotation;
        normalDialogue=CreateNormalParrotDialogue();
        isHitDialogue=CreateIsHitParrotDialogue();
        //set the interaction dialogue which is trigger when the dodo is near to the parrot
        interactionDialogue=GameObject.Find("DialogueInteraction");
 
    }
    void Update()
    {
        previousValueOfRotation=SetAnimator(previousValueOfRotation); //Set the parrot animation
        IsInRangeDialogue();
        if(Input.GetKeyDown(KeyCode.P))
        {
            TriggerDialogue(); // If the player is close to the parrot and press P, the parrot's dialogue begin
        }
        
    }

    public float SetAnimator(float _previousValueOfRotation)
    {
        bool rotate =false; //booleen that returns false if the parrot should not rotate, true if he rotates
        float valueOfActualRotation = parrotBody.rotation;
        //We look if the rotation of the parrot between -50 and 50 degree or if he does not rotates too fast
        if (Math.Abs(valueOfActualRotation)%360 >= 50 || Math.Abs(valueOfActualRotation)%360 >= 310 || Math.Abs(valueOfActualRotation - previousValueOfRotation) >10)
        {
            rotate=true; //we want the parrot animation with the stars
            isHit=true; //the parrot is hit by the dodo
        }
        animator.SetBool("isHit", rotate); //we set the value of rotation to the animator
        return parrotBody.rotation;
    }
    public bool IsInRangeDialogue()
    { //function to know if the parrot is in range for the dialogue. He is in range if the euclidienne distance between the parrot and the dodo is below 3
        if (Math.Sqrt(Math.Pow(parrotBody.position.x -dodoBody.position.x,2) + Math.Pow(parrotBody.position.y -dodoBody.position.y,2)) <2) 
        {
            interactionDialogue.GetComponentInChildren<Text>().text="Press P to speak";
            isInRange=true;
            return true;
        }
        else if(isInRange==true) //if the player just quit the range, we end the interaction dialogue text
        {
            interactionDialogue.GetComponentInChildren<Text>().text="";
            isInRange=false;
            DialogueManager.instance.EndDialogue();
        }
        return false;

    }
    private Dialogue CreateNormalParrotDialogue(){
        //Initialisation of the dialogue if the parrot is hit
        Dialogue dialogue = new Dialogue();
        dialogue.name= "Parrot";

        dialogue.lines = new DialogueLine[]
        {
            new DialogueLine("Croaaaa! Croaaaa!", false),   
            new DialogueLine("Press F to show the world what kind of species you are", false), 
            new DialogueLine("Then head west and open the chest. It will help you if you intend to travel in the forest.", false),       
        };

        return dialogue;

    }
    private Dialogue CreateIsHitParrotDialogue()
    {
        //Initialisation of the dialogue if the parrot is hit
        Dialogue dialogue = new Dialogue();
        dialogue.name= "Parrot";

        dialogue.lines = new DialogueLine[]
        {
            new DialogueLine("Croaaaa! Croaaaa!", false),
            new DialogueLine("Stop hiiiiiting me!", true, new Choice("I don't want...", new DialogueLine("Crroooaaaaaa !", false)), new Choice("My apologies",new DialogueLine("You're welllcome !", false))),            
        };

        return dialogue;
    }

    private Dialogue ChooseDialogue(){
        if( isHit==false || isHitDialogue.lines[1].choice2.isChosen==true)
        {
            isHitDialogue.lines[1].choice2.isChosen=false;
            isHit=false;
            return normalDialogue;
        }
        return isHitDialogue;

    }
    public void TriggerDialogue()
    { // if the player is close to the parrot and press P, the dialogue is trigger
        if ( IsInRangeDialogue()==true)
        {
            DialogueManager.instance.EndDialogue(); // close others dialogues
            Dialogue parrotDialogue=ChooseDialogue(); //choose the dialogue to display
            DialogueManager.instance.ChangingDialogue(parrotDialogue); //use the parrot dialogue
            DialogueManager.instance.StartDialogue(); // start dialogue
        }
    }
    

}
