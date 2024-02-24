using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour{
    private Slot[] slots;
    
    public int Initialization()
    {
        slots=GetComponentsInChildren<Slot>();
        return slots.Length;
    }
    public void UpdateDisplay(Item[] _currentItems)
    {

    }
}
