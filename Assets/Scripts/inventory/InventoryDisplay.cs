using UnityEngine;

public class InventoryDisplay : MonoBehaviour{
    private Slot[] slots;
    
    public int Initialization()
    {
        //we take all the slots that compose the inventory
        //And initialiazed all those slots
        slots=GetComponentsInChildren<Slot>();
        for (int i=0; i<slots.Length; i++)
        {
            slots[i].Initialize(this,i);
        }
        return slots.Length;
    }
    public void UpdateDisplay(Item[] _currentItems)
    {
        //we update the graphic interface foreach slots
        for(int i=0;i<slots.Length; i++)
        {
            slots[i].UpdateDisplay(_currentItems[i]);
        }

    }
    public void OnClickSlot(int _index)
    {
        //method if the player click on one slot
        //for now, this method don't do anything else that showing that the player click on one slot
        Debug.Log($"Click on slot : {_index}");
    }
}
