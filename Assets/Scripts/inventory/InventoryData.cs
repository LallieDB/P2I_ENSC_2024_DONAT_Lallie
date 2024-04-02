using System.Diagnostics;
using System.Threading;

public class InventoryData
{
    public static InventoryData instance;
    public Item[] items { get; private set; }

    public InventoryData(int _slotCount)
    {
        items = new Item[_slotCount];
    }

    public bool IsSlotAvailable(Item _itemToAdd)
    { //method that search if one slot is available to add an item
        foreach(var item in items)
        {
            if(item.AvailableFor(_itemToAdd))
            {
                return true;
            }
        }
        return false;
    }

    public void AddItem(ref Item _item)
    {//method to add the item in parameter
        for(int i=0; i<items.Length;i++)
        {
            if(_item.Empty)
                return;
            if(items[i].AvailableFor(_item))
            {
                items[i].Merge(ref _item);
            }
        }
    }

    public Item PickItem(int _slotId)
    {
        //method to pick one item in the slotID given in parameter
        
        if(_slotId> items.Length)
            throw new System.Exception($"id {_slotId} is out of inventory");
        //if there are more than one item in the slot, we just take one item
        if(items[_slotId].Count>1)
        {
            Item _itemPickLessOne=items[_slotId].OneLessCount(); //stock the item pick
            items[_slotId]=new Item(); //reinitialize the slot where the item is taken
            items[_slotId].Merge(ref _itemPickLessOne);
            return _itemPickLessOne;
        }

        Item _itemPick=items[_slotId]; //stock the item pick
        items[_slotId]=new Item();
        return _itemPick;
    }
    public bool HasItem(Item _itemToSearch)
    {//method that search if one item is in the inventory
        for(int i=0; i<items.Length;i++)
        {
            if(items[i].IsItem(_itemToSearch))
            {
                return true;
            }
        }
        return false;
    }
    public int FindItem(Item _itemToSearch)
    { //method that search an specific item in the inventory
    //return the SlotID of this item if he finds one
    //if he does not find an item, return the a number superieur of the slotID
        for(int i=0; i<items.Length;i++)
        {
            if(items[i].IsItem(_itemToSearch))
            {
                return i;
            }
        }
        throw new System.Exception($"the item {_itemToSearch} is out of inventory");
    }
}
