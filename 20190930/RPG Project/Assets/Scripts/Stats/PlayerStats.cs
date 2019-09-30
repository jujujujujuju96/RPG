using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharactorStats
{
    private void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem) {

        if (newItem != null) {
            armor.AddModifier(newItem.armorModifire);
            damage.AddModifier(newItem.damageModifire);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifire);
            damage.RemoveModifier(oldItem.damageModifire);
        }

    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}
