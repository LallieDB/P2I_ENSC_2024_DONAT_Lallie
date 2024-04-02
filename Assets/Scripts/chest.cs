using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class chest : MonoBehaviour
{
    private GameObject dialogueExplanation; // the ligne of dialogue that tells the user to use O to open the chest
    public Animator chestAnimator;
    private bool inRange; //booleen that tell if the user is in range to open the chest
    public Item poisonBottle; //the item in the chest
    private Inventory inventory;
    // Start is called before the first frame update
    void Awake()
    {   //initialization of attributs
        dialogueExplanation=GameObject.Find("DialogueInteraction");
        dialogueExplanation.GetComponentInChildren<Text>().text="";
        inRange=false;
        inventory=FindObjectOfType<Inventory>();
    }
    
    // Update is called once per frame
    void Update()
    {  
        if(Input.GetKeyDown(KeyCode.O) && inRange==true) 
        {
            OpenChest();
            inventory.AddItem(poisonBottle);
        }
    }
    public void OpenChest(){
        //method which is called when the chest is open by the player
        chestAnimator.SetTrigger("OpenChest");
        dialogueExplanation.GetComponentInChildren<Text>().text=""; //the dialogue on the chest disappear 
        inRange=false;
        this.GetComponent<BoxCollider2D>().enabled=false; // the box collider on the chest disappear, 
        // so the inRange is always false and there is no more message near the chest after that the chest is opened
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { // this method is called when the dodo enters in the box collider of the chest
        if (collision.CompareTag("Player"))
        {
            dialogueExplanation.GetComponentInChildren<Text>().text="Press O to open the chest";
            inRange=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {// this method is called when the dodo leaves the box collider of the chest
        if (collision.CompareTag("Player"))
        {
            dialogueExplanation.GetComponentInChildren<Text>().text="";
            inRange=false;
        }
    }
}
