using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class chest : MonoBehaviour
{
    private Text interationExplanation;
    public Animator chestAnimator;
    private bool inRange;
    // Start is called before the first frame update
    void Awake()
    {
        interationExplanation=GameObject.Find("InteractionText").GetComponent<Text>();
        interationExplanation.text="";
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
        GetComponent<BoxCollider2D>().enabled=true;
        interationExplanation.enabled=true;
        inRange=false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interationExplanation.text="Press O to Open the chest";
            inRange=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interationExplanation.text="";
            inRange=false;
        }
    }
}
