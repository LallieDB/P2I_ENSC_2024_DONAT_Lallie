using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour{
    private Slot[] slots;
    
    public int Initialization()
    {
        slots=GetComponentsInChildren<Slot>();
        for (int i=0; i<slots.Length; i++)
        {
            slots[i].Initialize(this,i);
        }
        return slots.Length;
    }
    public void UpdateDisplay(Item[] _currentItems)
    {
        for(int i=0;i<slots.Length; i++)
        {
            slots[i].UpdateDisplay(_currentItems[i]);
        }

    }
}
