using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;   
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else 
            {
                slots[i].ClearSlot();
            }
        }
        Debug.Log("UPDATING UI");
    }
}
