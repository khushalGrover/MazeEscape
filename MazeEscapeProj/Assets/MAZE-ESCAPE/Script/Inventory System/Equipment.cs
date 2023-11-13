using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory System/Equipment")]
public class Equipment : Item
{
   public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {

        base.Use();
        // Equip the item
        EquipmentManager.instance.Equip(this);
        // Debug.Log("Using " + this);
        // Remove it from the inventory
        RemoveFromInventory();
    }

   
    // public override void RemoveFromInventory()
    // {
    //     base.RemoveFromInventory();
    //     EquipmentManager.instance.Unequip((int)equipSlot);
    // }

}   


public enum EquipmentSlot 
{ 
    Default,
    Head, 
    Chest, 
    Legs, 
    Weapon, 
    Shield, 
    Feet,  
    Consumable
}