using UnityEngine;
[CreateAssetMenu(menuName = "ItemData")]

public class ItemData : ScriptableObject
{
    [SerializeField] public string ItemName; //the item name
    [SerializeField] public int stackMaxCount; //the maximum number by solt of this item
    [SerializeField] public Sprite icon; //the item image
}
