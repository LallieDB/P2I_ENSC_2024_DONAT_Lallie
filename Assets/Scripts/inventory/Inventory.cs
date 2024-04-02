using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryDisplay display;
    private InventoryData data;
    public void Awake()
    { // intialization of the inventory
        int slotcount=display.Initialization(); //we take the number of slot of this inventory
        data=new InventoryData(slotcount);
        display.UpdateDisplay(data.items);
    }
    public Item AddItem( Item _item)
    {//method to add the item given in parameter
        if (!data.IsSlotAvailable(_item)) return _item;
        data.AddItem(ref _item);
        display.UpdateDisplay(data.items);
        return _item;
    }
    public Item PickItem(int _slotID)
    { //pick the item in the slotID given, this action deletes the item from the inventory
        Item _choosenItem= data.PickItem(_slotID);
        display.UpdateDisplay(data.items);
        return _choosenItem;
    }
    public bool IsItemInInventory(Item _item)
    { //method to search if a item is in the inventory and return true or false
    if (data.HasItem(_item)==true)
    {
        return true;
    }
    return false;
    }

    public bool FindAndPickItem(Item _item)
    { //function to search if a item is in the inventory and to pick it if this is the case
    //if the item is find and pick, it returns true
    //if the item is not in the inventory, it returns false
    if (IsItemInInventory(_item)==true)
    {
        //if the item is in the inventory, the function find her slot and pick the item
        int _slotOfSearchedItem=data.FindItem(_item);
        PickItem(_slotOfSearchedItem);
        return true;
    }
    Debug.Log($"The item {_item} was not found");
    return false;
    }

}
