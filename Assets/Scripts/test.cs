using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private Item itemToPush, pickedItem;
    private Inventory inventory;
    void Awake(){
        inventory=FindObjectOfType<Inventory>();
        }
        
    [ContextMenu("TestPush")]
    private void Add() 
    {
        itemToPush=inventory.AddItem(itemToPush);
    }
    [ContextMenu("Picked")]
    private void Pick() 
    {
        pickedItem=inventory.PickItem(11);
    }
}
