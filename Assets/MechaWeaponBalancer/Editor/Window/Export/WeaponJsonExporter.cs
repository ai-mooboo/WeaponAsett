using UnityEngine;
using UnityEditor;
using System.IO;

public static class WeaponJsonExporter
{
    [MenuItem(
        "Tools/Mecha Weapon Balancer/Export Selected Weapon Json")]
    static void ExportSelectedWeapon()
    {
        // 選択中のWeaponData取得
        WeaponData weapon =
            Selection.activeObject as WeaponData;

        // 未選択チェック
        if (weapon == null)
        {
            Debug.LogError(
                "WeaponDataを選択してください");
            return;
        }

        // JSON化
        string json =
            JsonUtility.ToJson(
                weapon,
                true);

        // 保存先フォルダ
        string folder =
            "Assets/MechaWeaponBalancer/Exports";

        // フォルダ存在確認
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        // 保存パス
        string path =
            folder
            + "/"
            + weapon.weaponName
            + ".json";

        // JSON保存
        File.WriteAllText(
            path,
            json);

        // Unity更新
        AssetDatabase.Refresh();

        Debug.Log(
            "JSON Exported : "
            + path);
    }
}