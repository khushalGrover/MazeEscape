using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Item")]
public class Item : ScriptableObject
{
    public int MaxStack;
    new public string name = "New Item";
    public string ItemDesc;
    public bool isDefaultItem = false;
    public Sprite icon = null;
    public GameObject ItemPrefab;

    public virtual void Use()
    {
        // Use the item
        
        // Something might happen
        Debug.Log("Using " + name);

    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }


}
