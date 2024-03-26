using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private Item itemToPush, itemToSearch, pickedItem;
    private bool IsFind;
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
        pickedItem=inventory.PickItem(1);
    }
    [ContextMenu("Search")]
    private void Search() 
    {
        IsFind=inventory.FindAndPickItem(itemToSearch);
    }
}
