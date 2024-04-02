using UnityEngine;

[System.Serializable]
public struct Item 
{
    [SerializeField] private int count;
    [SerializeField] private ItemData data;

    //try to put the item in the emplacement
    public void Merge(ref Item _itemToMerge)
    {
        //method to merge same items in one slot : one which is already on a slot and the same item that we want to put
        //in the inventory with the fist item
        if (Full) return;
        if (Empty) data=_itemToMerge.Data;
        if (_itemToMerge.Data != data) throw new System.Exception("The two items are different");

        int _total = _itemToMerge.count + count;

        if(_total<= data.stackMaxCount)
        {
            count=_total;
            _itemToMerge.count=0;
            return;
        }
        count=data.stackMaxCount;
        _itemToMerge.count=_total - count;
    }
    public Item OneLessCount() {
        //method to decrease by one the number of one item in the inventory
        if(count>1)
        {
            count=count-1;
        }
        return this;
    } 
 
    // Search if the item can be stock in the slot emplacement
    public bool AvailableFor(Item _item) => Empty || (Data ==_item.data && !Full) ;
    public bool IsItem(Item _item) => Data ==_item.data;

    public ItemData Data => data;
    public bool Full => data && count >= data.stackMaxCount;
    public bool Empty => count==0 || data==null;
    public int Count => count;
    
} 