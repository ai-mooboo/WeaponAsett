using UnityEngine;



[CreateAssetMenu(
    menuName = "Weapon Balancer/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Basic")]

    public string weaponName;

    public WeaponType type;

    [TextArea]
    public string description;

    // =========================
    // Common
    // =========================

    [Header("Common")]

    public float damage = 10;

    public float attackRate = 1;

    public float range = 10;

    public float weight = 1;

    // =========================
    // Ranged
    // =========================

    [Header("Ranged")]

    public int ammo = 30;

    public float reloadTime = 2;

    public float accuracy = 100;

    // =========================
    // Melee
    // =========================

    [Header("Melee")]

    public float knockback = 5;

    public float stunTime = 0.2f;

    public int comboCount = 3;

    public float swingAngle = 120;

    // =========================
    // Calculated
    // =========================

    [Header("Calculated")]

    [HideInInspector]
    public float dps;

    void OnValidate()
    {
        dps = damage * attackRate;
    }
}