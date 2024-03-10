public class InventoryData
{
    public static InventoryData instance;
    public Item[] items { get; private set; }

    public InventoryData(int _slotCount)
    {
        items = new Item[_slotCount];
    }

    public bool IsSlotAvailable(Item _itemToAdd)
    {
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
    {
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
        if(_slotId> items.Length)
            throw new System.Exception($"id {_slotId} is out of inventory");
        Item _itemPick=items[_slotId]; //stock the item pick
        items[_slotId]=new Item(); //reinitialize the slot where the item is taken
        return _itemPick;

    }
}
