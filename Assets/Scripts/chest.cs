using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class chest : MonoBehaviour
{
    private GameObject dialogueExplanation;
    public Animator chestAnimator;
    private bool inRange;
    // Start is called before the first frame update
    void Awake()
    {
        dialogueExplanation=GameObject.Find("DialogueInteraction");
        dialogueExplanation.GetComponentInChildren<Text>().text="";
        inRange=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O) && inRange==true)
        {
            OpenChest();
        }
        
    }
    public void OpenChest(){
        chestAnimator.SetTrigger("OpenChest");
        dialogueExplanation.GetComponentInChildren<Text>().text="";
        inRange=false;
        this.GetComponent<BoxCollider2D>().enabled=false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueExplanation.GetComponentInChildren<Text>().text="Press O to open the chest";
            inRange=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueExplanation.GetComponentInChildren<Text>().text="";
            inRange=false;
        }
    }
}
