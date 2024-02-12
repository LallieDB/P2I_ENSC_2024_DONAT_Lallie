using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantScript : MonoBehaviour
{
    private GameObject interactionDialogue;
    private Dialogue plantDialogue;
    public Rigidbody2D dodoBody;
    public Rigidbody2D plantBody;
    public bool isInRange;
    // Start is called before the first frame update
    void Start()
    {
        interactionDialogue=GameObject.Find("DialogueInteraction");
        plantDialogue=CreatePlantDialogue();
        isInRange=false;
    }

    // Update is called once per frame
    void Update()
    {
        isInRange=IsInRangeDialogue(); //update of the dodo position compares to the plant position
        if (Input.GetKeyDown(KeyCode.P)) //if the dodo is in range and the player press P, the dialogue begins
        {
            TriggerDialogue();
        }
        
    }
    private bool IsInRangeDialogue()
    { //function to know if the parrot is in range for the dialogue. He is in range if the euclidienne distance between the parrot and the dodo is below 3
        if (Math.Sqrt(Math.Pow(plantBody.position.x -dodoBody.position.x,2) + Math.Pow(plantBody.position.y -dodoBody.position.y,2)) <2) 
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
    public void TriggerDialogue()
    { // if the player is close to the parrot and press P, the dialogue is trigger
        if ( IsInRangeDialogue()==true)
        {
            DialogueManager.instance.EndDialogue(); // close others dialogues
            DialogueManager.instance.ChangingDialogue(plantDialogue); //use the parrot dialogue
            DialogueManager.instance.StartDialogue(); // start dialogue
        }
    }
    
    
    private Dialogue CreatePlantDialogue()
    {
        Dialogue dialogue = new Dialogue();
        dialogue.name = "Plant";
        dialogue.lines = new DialogueLine[]
        {
            new DialogueLine("Hello there !",false),
            new DialogueLine("You seem to be a nice bird. Please bring me water, my leafs start to deplenished",false),
        };
        return dialogue;
    }
}
