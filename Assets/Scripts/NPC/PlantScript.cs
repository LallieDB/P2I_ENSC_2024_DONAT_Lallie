using System;
using UnityEngine;
using UnityEngine.UI;

public class PlantScript : MonoBehaviour
{
    private GameObject interactionDialogue;
    private GameObject questIcon;
    private GameObject plant;
    public Rigidbody2D dodoBody;
    public Rigidbody2D plantBody;
    private Inventory inventory;
    private Dialogue plantDialogue;
    public Item poisonBottle;
    public bool isInRange;
    public bool acceptQuest;
    public bool playerHasWater;
    // Start is called before the first frame update
    void Start()
    {   //assignation of GameObject
        questIcon=GameObject.Find("quest_icon");
        interactionDialogue=GameObject.Find("DialogueInteraction");
        plant=GameObject.Find("Plant");
        //Assignation of the first dialogue, inventory and booleans
        plantDialogue=CreatePlantDialogue();
        inventory=FindObjectOfType<Inventory>();
        isInRange=false;
        acceptQuest=false;
        playerHasWater=false;
    }

    // Update is called once per frame
    void Update()
    {
        isInRange=IsInRangeDialogue(); //update of the dodo position compares to the plant position
        if (Input.GetKeyDown(KeyCode.P)) //if the dodo is in range and the player press P, the dialogue begins
        {
            TriggerDialogue();
        }
        //if the player accept the quest, the dialogue changes
        if (acceptQuest==false && plantDialogue.lines[1].choice1.isChosen==true)
        {
            acceptQuest=true;
            questIcon.SetActive(false);
            plantDialogue=PlantWatitingForWaterAndYouDoNotHaveWater();
        }
        //if the player have accepted the quest and picks the poison bottle, the dialogue changes
        if(acceptQuest==true && playerHasWater==false)
        {
            if (inventory.IsItemInInventory(poisonBottle)==true)
            {
                plantDialogue=PlantWaitingWaterDialogueAndYouHaveWater();
                playerHasWater=true;
            }
        }
        //if the player give the poison bottle at the plant, he succeds at the quest, the plant disappear
        if( acceptQuest==true && playerHasWater==true && plantDialogue.lines[1].choice1.isChosen==true)
        {
            HasWater();
        }
        
    }
    private void HasWater()
    {
        if (inventory.FindAndPickItem(poisonBottle)==true)
        { 
            Destroy(plant);
            Destroy(plantBody);
            interactionDialogue.GetComponentInChildren<Text>().text="";
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
            //if the quest is accepted, we change the dialogue
            DialogueManager.instance.EndDialogue(); // close others dialogues
            DialogueManager.instance.ChangingDialogue(plantDialogue); //use the parrot dialogue
            DialogueManager.instance.StartDialogue(); // start dialogue
        }
    }
    
    
    private Dialogue CreatePlantDialogue()
    { //Creation of the first dialogue of the parrot plant
        Dialogue dialogue = new Dialogue();
        dialogue.name = "Plant";
        dialogue.lines = new DialogueLine[]
        {
            new DialogueLine("Hello there !",false),
            new DialogueLine("You seem to be a nice bird. Please bring me water, my leafs start to deplenished",true, 
            new Choice("Yes", new DialogueLine("Thank you, you are a good bird.", false)), new Choice("No", new DialogueLine("Pleease, I am begging you", false))),
        };
        return dialogue;
    }
    private Dialogue PlantWaitingWaterDialogueAndYouHaveWater()
    { //Creation of the dialogue when the player accept the quest of the parrot plant
        Dialogue dialogue = new Dialogue();
        dialogue.name = "Plant";
        dialogue.lines = new DialogueLine[]
        {
            new DialogueLine("Hello again nice bird !",false),
            new DialogueLine("Do you have water ?",true, 
            new Choice("Yes", new DialogueLine("Thank you so much ! Oh, but why me leafs deplenished so fast ?!?!?!?!", false)), new Choice("No", new DialogueLine("Hurry !", false))),
        };
        return dialogue;

    }
    private Dialogue PlantWatitingForWaterAndYouDoNotHaveWater()
    {
        //Creation of the dialogue when the player accept the quest of the parrot plant
        Dialogue dialogue = new Dialogue();
        dialogue.name = "Plant";
        dialogue.lines = new DialogueLine[]
        {
            new DialogueLine("Hello again nice bird !",false),
            new DialogueLine("Do you have water ?",true, 
            new Choice("Yes", new DialogueLine("LIAR !!!!", false)), new Choice("No", new DialogueLine("Hurry !", false))),
        };
        return dialogue;

    }
}
