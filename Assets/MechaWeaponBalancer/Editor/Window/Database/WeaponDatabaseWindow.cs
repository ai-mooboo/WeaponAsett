using UnityEngine;
using UnityEditor;
using System.Linq;

public class WeaponDatabaseWindow :
    EditorWindow
{
    WeaponData[] weapons;

    Vector2 scroll;

    int tab;

    [MenuItem("Tools/Weapon Database")]
    static void Open()
    {
        GetWindow<WeaponDatabaseWindow>(
            "Weapon Database");
    }

    void OnEnable()
    {
        RefreshDatabase();
    }

    void OnGUI()
    {
        DrawTabs();

        GUILayout.Space(5);

        DrawWeaponList();
    }

    void DrawTabs()
    {
        tab = GUILayout.Toolbar(
            tab,
            new string[]
            {
                "Ranged",
                "Melee"
            });
    }

    void DrawWeaponList()
    {
        scroll =
            GUILayout.BeginScrollView(scroll);

        foreach (WeaponData weapon in weapons)
        {
            if (weapon == null)
                continue;

            bool isRanged =
                weapon.type == WeaponType.Gun
                || weapon.type == WeaponType.Launcher
                || weapon.type == WeaponType.Beam;

            bool isMelee =
                weapon.type == WeaponType.Melee;

            if (tab == 0 && !isRanged)
                continue;

            if (tab == 1 && !isMelee)
                continue;

            DrawWeaponRow(weapon);
        }

        GUILayout.EndScrollView();
    }

    void DrawWeaponRow(WeaponData weapon)
    {
        GUILayout.BeginVertical("box");

        GUILayout.BeginHorizontal();

        GUILayout.Label(
            weapon.weaponName,
            GUILayout.Width(120));

        GUILayout.Label(
            weapon.type.ToString(),
            GUILayout.Width(80));

        GUILayout.Label(
            "DMG : " + weapon.damage,
            GUILayout.Width(90));

        GUILayout.Label(
            "DPS : " + weapon.dps,
            GUILayout.Width(90));

        GUILayout.Label(
            "Range : " + weapon.range,
            GUILayout.Width(90));

        GUILayout.EndHorizontal();

        GUILayout.Space(3);

        // =========================
        // Melee
        // =========================

        if (weapon.type == WeaponType.Melee)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Label(
                "Knockback : "
                + weapon.knockback,
                GUILayout.Width(150));

            GUILayout.Label(
                "Combo : "
                + weapon.comboCount,
                GUILayout.Width(120));

            GUILayout.Label(
                "Stun : "
                + weapon.stunTime,
                GUILayout.Width(120));

            GUILayout.EndHorizontal();
        }

        // =========================
        // Ranged
        // =========================

        else
        {
            GUILayout.BeginHorizontal();

            GUILayout.Label(
                "Ammo : "
                + weapon.ammo,
                GUILayout.Width(120));

            GUILayout.Label(
                "Reload : "
                + weapon.reloadTime,
                GUILayout.Width(120));

            GUILayout.Label(
                "Accuracy : "
                + weapon.accuracy,
                GUILayout.Width(140));

            GUILayout.EndHorizontal();
        }

        GUILayout.Space(5);

        if (GUILayout.Button(
            "Select",
            GUILayout.Height(25)))
        {
            Selection.activeObject = weapon;
        }

        GUILayout.EndVertical();

        GUILayout.Space(4);
    }

    void RefreshDatabase()
    {
        string[] guids =
            AssetDatabase.FindAssets(
                "t:WeaponData");

        weapons =
            guids
            .Select(guid =>
                AssetDatabase.LoadAssetAtPath<WeaponData>(
                    AssetDatabase.GUIDToAssetPath(guid)))
            .ToArray();
    }
}