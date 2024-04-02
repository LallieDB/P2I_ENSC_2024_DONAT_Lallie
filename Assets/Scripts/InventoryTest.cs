using UnityEngine;

public class test : MonoBehaviour
{ // this class is used to test the inventory methods
    [SerializeField] private Item itemToPush, itemToSearch, pickedItem;
    private bool IsFind;
    private Inventory inventory;
    void Awake()
    {
        inventory=FindObjectOfType<Inventory>();
    }
        
    [ContextMenu("TestPush")] //test to add an item in the inventory
    private void Add() 
    {
        itemToPush=inventory.AddItem(itemToPush);
    }
    [ContextMenu("Picked")] //test to pick the first item in the inventory
    private void Pick() 
    {
        pickedItem=inventory.PickItem(1);
    }
    [ContextMenu("Search")] //test to search an item in the inventory
    private void Search() 
    {
        IsFind=inventory.FindAndPickItem(itemToSearch);
    }
}
