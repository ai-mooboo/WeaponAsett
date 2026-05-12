using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponContoroller : MonoBehaviour
{
    public WeaponBase currentWeapon;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.Attack();
        }
    }
}
