using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Text itemCountText;
    [SerializeField] private Image itemImage;
    private int index;
    private InventoryDisplay inventoryDisplay;
    public void Initialize( InventoryDisplay _inventoryDisplay, int _index)
    {
        index=_index;
        inventoryDisplay=_inventoryDisplay;
    }
    public void UpdateDisplay(Item _item)
    {
        if(!_item.Empty)
        {
            itemCountText.text=_item.Count.ToString();
            itemImage.sprite=_item.Data.icon;
            itemImage.color=Color.white;
            return;
        }
        itemCountText.text="";
        itemImage.sprite=null;
        itemImage.color= new Color(0,0,0,0);

    }
}