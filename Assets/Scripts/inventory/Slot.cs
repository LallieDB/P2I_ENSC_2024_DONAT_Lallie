using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Text itemCountText;
    [SerializeField] private Image itemImage;
    private int index;
    private InventoryDisplay inventoryDisplay;
    private Button button;
    public void Initialize( InventoryDisplay _inventoryDisplay, int _index)
    { //initialization
        button=GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        index=_index;
        inventoryDisplay=_inventoryDisplay;
    }
    public void UpdateDisplay(Item _item)
    { //method that update the display by putting th chosen item in the slot
    // if the item is null, the slot is reiniatilazed
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
    private void OnClick(){
        //method if the player click on this slot
        inventoryDisplay.OnClickSlot(index);
    }
}