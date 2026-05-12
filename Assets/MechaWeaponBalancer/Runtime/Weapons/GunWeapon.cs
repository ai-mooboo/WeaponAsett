using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : WeaponBase
{
    public Camera cam;
         public override void Attack()
        {
            if(!CanAttack())
                return;
            SetAttackCooldown();

            Ray ray = 
                        cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit,
            weaponData.range))
        {
            Damageable damageable = 
                hit.collider.GetComponent<Damageable>();

            if(damageable != null)
            {
                damageable.TakeDamage(weaponData.damage);
            }

            Debug.Log(
                weaponData.weaponName + " Fire");
        }
    }
}
