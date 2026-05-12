using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="weapon System/Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Basic")]

    public string weaponName;//武器名
    public Sprite icon;//アイコン
    
    [Header("Stats")]
    public float damage = 10f;//ダメージ
    public float attackRate = 1f;//攻撃速度
    public float range = 10f;//射程

    [Header("Ammo")]
    public int maxAmmo = 30;//最大弾薬数
    public bool infiniteAmmo = false;//無限弾薬


}
