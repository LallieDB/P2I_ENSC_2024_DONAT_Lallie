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
        display.Initialization();
        data=new InventoryData();

    }

}
public class InventoryDisplay : MonoBehaviour{
    private Slot[] slots;
    public void Initialization()
    {
        // slots=GetComponentInChildren
    }
}

public class InventoryData{

}