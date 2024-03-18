using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryDisplay display;
    private InventoryData data;
    public void Awake()
    {
        int slotcount=display.Initialization();
        data=new InventoryData(slotcount);
        display.UpdateDisplay(data.items);
    }
    public Item AddItem( Item _item)
    {
        if (!data.IsSlotAvailable(_item)) return _item;
        data.AddItem(ref _item);
        display.UpdateDisplay(data.items);
        return _item;
    }
    public Item PickItem(int _slotID)
    {
        Item _choosenItem= data.PickItem(_slotID);
        display.UpdateDisplay(data.items);
        return _choosenItem;
    }

    public bool FindAndPickItem(Item _item)
    { //function to search if a item is in the inventory a,d to pick it if this is the case
    //if the item is find and pick, it returns true
    //if the item is not in the inventory, it returns false
    if (data.HasItem(_item)==true)
    {
        int _slotOfSearchedItem=data.FindItem(_item);
    
        PickItem(_slotOfSearchedItem);
        Debug.Log($"the item is in the slot : {_slotOfSearchedItem} ");
        return true;


    }
    Debug.Log("No item was found");
    return false;
    }

}
