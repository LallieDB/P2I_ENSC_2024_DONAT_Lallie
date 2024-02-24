using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryDisplay display;
    private InventoryData data;
    public void Awake()
    {
        int slotcount=display.Initialization();
        data=new InventoryData(slotcount);
    }
    public Item AddItem(Item _item)
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

}
