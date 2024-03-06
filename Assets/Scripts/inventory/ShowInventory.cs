using UnityEngine;
using UnityEngine.UI;

public class ShowInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inventoryMenu;
    private bool isInventoryMenuDisplay;
    private Button button;

    void Start()
    {
        button=GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        // inventoryMenu=GameObject.Find("Inventory");
        isInventoryMenuDisplay=false;
        inventoryMenu.SetActive(false);
        
    }
    private void OnClick()
    {
        isInventoryMenuDisplay=!isInventoryMenuDisplay;
        inventoryMenu.SetActive(isInventoryMenuDisplay);
    }
}
