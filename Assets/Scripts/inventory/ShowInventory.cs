using UnityEngine;
using UnityEngine.UI;

public class ShowInventory : MonoBehaviour
{
    // class to display the inventory when the player click on the top-right button
    public GameObject inventoryMenu;
    private bool isInventoryMenuDisplay;
    private Button button;

    void Start()
    {
        button=GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        isInventoryMenuDisplay=false;
        inventoryMenu.SetActive(false);
        
    }
    private void OnClick()
    {   //method when the player click on the button that manage the inventory
        isInventoryMenuDisplay=!isInventoryMenuDisplay;
        inventoryMenu.SetActive(isInventoryMenuDisplay);
    }
}
