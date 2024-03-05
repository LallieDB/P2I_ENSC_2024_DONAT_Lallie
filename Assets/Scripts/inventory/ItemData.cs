using UnityEngine;
[CreateAssetMenu(menuName = "ItemData")]

public class ItemData : ScriptableObject
{
    [SerializeField] public string ItemName;
    [SerializeField] public int stackMaxCount;
    [SerializeField] public Sprite icon;
}
