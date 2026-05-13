using UnityEngine;
using UnityEditor;

public class WeaponCreatorWindow :
    EditorWindow
{
    string weaponName =
        "New Weapon";

    WeaponType weaponType =
        WeaponType.Gun;

    string description = "";

    // =========================
    // Common
    // =========================

    float damage = 10;

    float attackRate = 1;

    float range = 10;

    float weight = 1;

    // =========================
    // Ranged
    // =========================

    int ammo = 30;

    float reloadTime = 2;

    float accuracy = 100;

    // =========================
    // Melee
    // =========================

    float knockback = 5;

    float stunTime = 0.2f;

    int comboCount = 3;

    float swingAngle = 120;

    Vector2 scroll;

    [MenuItem("Tools/Weapon Creator")]
    static void Open()
    {
        GetWindow<WeaponCreatorWindow>(
            "Weapon Creator");
    }

    void OnGUI()
    {
        scroll =
            GUILayout.BeginScrollView(scroll);

        GUILayout.Label(
            "Weapon Creator",
            EditorStyles.boldLabel);

        GUILayout.Space(5);

        // =========================
        // Basic
        // =========================

        GUILayout.Label(
            "Basic",
            EditorStyles.boldLabel);

        weaponName =
            EditorGUILayout.TextField(
                "Weapon Name",
                weaponName);

        weaponType =
            (WeaponType)
            EditorGUILayout.EnumPopup(
                "Weapon Type",
                weaponType);

        description =
            EditorGUILayout.TextField(
                "Description",
                description);

        GUILayout.Space(10);

        // =========================
        // Common
        // =========================

        GUILayout.Label(
            "Common",
            EditorStyles.boldLabel);

        damage =
            EditorGUILayout.FloatField(
                "Damage",
                damage);

        attackRate =
            EditorGUILayout.FloatField(
                "Attack Rate",
                attackRate);

        range =
            EditorGUILayout.FloatField(
                "Range",
                range);

        weight =
            EditorGUILayout.FloatField(
                "Weight",
                weight);

        GUILayout.Space(10);

        // =========================
        // Melee
        // =========================

        if (weaponType == WeaponType.Melee)
        {
            GUILayout.Label(
                "Melee",
                EditorStyles.boldLabel);

            knockback =
                EditorGUILayout.FloatField(
                    "Knockback",
                    knockback);

            stunTime =
                EditorGUILayout.FloatField(
                    "Stun Time",
                    stunTime);

            comboCount =
                EditorGUILayout.IntField(
                    "Combo Count",
                    comboCount);

            swingAngle =
                EditorGUILayout.FloatField(
                    "Swing Angle",
                    swingAngle);
        }

        // =========================
        // Ranged
        // =========================

        else
        {
            GUILayout.Label(
                "Ranged",
                EditorStyles.boldLabel);

            ammo =
                EditorGUILayout.IntField(
                    "Ammo",
                    ammo);

            reloadTime =
                EditorGUILayout.FloatField(
                    "Reload Time",
                    reloadTime);

            accuracy =
                EditorGUILayout.FloatField(
                    "Accuracy",
                    accuracy);
        }

        GUILayout.Space(20);

        if (GUILayout.Button(
            "Create Weapon",
            GUILayout.Height(40)))
        {
            CreateWeapon();
        }

        GUILayout.EndScrollView();
    }

    void CreateWeapon()
    {
        WeaponData data =
            ScriptableObject
            .CreateInstance<WeaponData>();

        // =========================
        // Basic
        // =========================

        data.weaponName = weaponName;

        data.type = weaponType;

        data.description = description;

        // =========================
        // Common
        // =========================

        data.damage = damage;

        data.attackRate = attackRate;

        data.range = range;

        data.weight = weight;

        // =========================
        // Melee
        // =========================

        data.knockback = knockback;

        data.stunTime = stunTime;

        data.comboCount = comboCount;

        data.swingAngle = swingAngle;

        // =========================
        // Ranged
        // =========================

        data.ammo = ammo;

        data.reloadTime = reloadTime;

        data.accuracy = accuracy;

        // =========================
        // Save
        // =========================

        string folderPath =
            "Assets/MechaWeaponBalancer/Data";

        if (!AssetDatabase
            .IsValidFolder(folderPath))
        {
            AssetDatabase.CreateFolder(
                "Assets/MechaWeaponBalancer",
                "Data");
        }

        string assetPath =
            folderPath
            + "/"
            + weaponName
            + ".asset";

        AssetDatabase.CreateAsset(
            data,
            assetPath);

        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = data;

        Debug.Log(
            "Created Weapon : "
            + weaponName);
    }
}