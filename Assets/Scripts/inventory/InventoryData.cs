using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[System.Serializable]
public class InventoryData{
    public Item[] items {get; private set;}
    public InventoryData(int _slotCount){
        items= new Item[_slotCount];
    }
    public bool IsSlotAvailable(Item _itemToAdd)
    {
        throw new System.NotImplementedException();
    }
    public Item AddItem(Item _item)
    {
        throw new System.NotImplementedException();
    }
    public Item PickItem(int _slotId)
    {
        throw new System.NotImplementedException();
    }

}