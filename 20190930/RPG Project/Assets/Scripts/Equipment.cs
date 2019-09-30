using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredMeshRegions;


    public int armorModifire;
    public int damageModifire;

    public override void use()
    {
        base.use();

        //装备上装备
        EquipmentManager.instance.Equip(this);
        //从背包中消除掉
        RemoveFromInventory();
    }


}
public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }
public enum EquipmentMeshRegion {Legs,Arms,Torso};
