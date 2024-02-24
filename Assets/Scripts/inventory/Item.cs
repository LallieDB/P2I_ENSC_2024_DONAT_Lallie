using System.Data.Common;
using UnityEngine;

[System.Serializable]
public struct Item 
{
    [SerializeField] private int count;
    [SerializeField] private ItemData data;

    //try to put the item in the emplacement
    public void Merge(ref Item _itemToMerge){
        if (Full) return;
        else if (data==null)
        {
            data=_itemToMerge.data;
            return;
        }
        else if (_itemToMerge.data != data) throw new System.Exception("The two items are different");
        
        int _total = _itemToMerge.count + count;
        if(_total<= data.stackMaxCount)
        {
            count=_total;
            _itemToMerge.count=0;
            return;
        }
        count=data.stackMaxCount;
        _itemToMerge.count=_total-count;
        return;

    }

    // Search if the item can be stock in the slot emplacement
    public bool AvailableFor(Item _item) => Empty || (data ==_item.data && !Full) ;

    public ItemData Data => data;
    public bool Full => data && count>= data.stackMaxCount;
    public bool Empty => count==0 || data==null;
    
} 