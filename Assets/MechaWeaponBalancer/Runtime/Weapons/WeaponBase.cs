
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;

    protected float nextAttackTime;

    public virtual void Attack()
    {
    }

    protected bool CanAttack()
    {
        return Time.time >= nextAttackTime;
    }

    protected void SetAttackCooldown()
    {
        nextAttackTime = 
            Time.time + (1f / weaponData.attackRate);
    }
}
