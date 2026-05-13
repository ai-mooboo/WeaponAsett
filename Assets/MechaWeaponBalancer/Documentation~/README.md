\# Mecha Weapon Balancer



Unity用 武器バランス調整・データベースアセット



\---



\# 機能



\- 武器作成ツール

\- 武器データベース

\- 近距離 / 遠距離 武器対応

\- JSON Export

\- DPS自動計算



\---



\# フォルダ構成



Assets/

└── MechaWeaponBalancer/

&#x20;   ├── Runtime/

&#x20;   ├── Editor/

&#x20;   ├── Data/

&#x20;   └── Exports/



\---



\# 起動方法



\## Weapon Creator



Tools

→ Mecha Weapon Balancer

→ Weapon Creator



\---



\## Weapon Database



Tools

→ Mecha Weapon Balancer

→ Weapon Database



\---



\# 武器作成方法



1\. Weapon Creator を開く

2\. Weapon Type を選択

3\. ステータス入力

4\. Create Weapon を押す



作成されたWeaponDataは：



Assets/MechaWeaponBalancer/Data/



に保存されます。



\---



\# JSON Export



\## 全武器Export



Tools

→ Mecha Weapon Balancer

→ Export All Weapons Json



ExportされたJSONは：



Assets/MechaWeaponBalancer/Exports/



へ保存されます。



\---



\# 武器タイプ



\- Gun

\- Melee

\- Launcher

\- Beam

\- Special



\---



\# ステータス説明



|項目|説明|

|---|---|

|Damage|攻撃力|

|Attack Rate|攻撃速度|

|Range|射程|

|Weight|重量|

|Ammo|装弾数|

|Reload Time|リロード時間|

|Accuracy|命中率|

|Knockback|吹き飛ばし|

|Combo Count|コンボ数|

|Stun Time|スタン時間|



\---



\# 武器例



\## Hammer



\- Damage : 40

\- Knockback : 15

\- Combo Count : 3



\---



\## Rifle



\- Damage : 20

\- Ammo : 30

\- Accuracy : 95



\---



\# 対応UnityVersion



Unity 2022.3 以上



\---



\# 作者



YourTeam

