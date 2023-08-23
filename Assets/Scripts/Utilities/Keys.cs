using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Analytics;
using GunduzDev.Values;

namespace GunduzDev.Keys
{
    public struct GameSaveData
    {
        public int playerLevel;         // Represents the player's level
        public int currentXP;           // Represents the player's current XP
        public int goldAmount;          // Represents the amount of gold the player has
        public int diamondAmount;       // Represents the amount of diamonds the player has
        public int currentEnvironment;  // Represents the current environment the player is in
        public bool[] unlockedLevels;   // Represents the levels unlocked by the player
        public int Level;
        public int Coin;
        public int Score;
        public int Gold, Diamand;
        public bool SFX;
        public bool VFX;
        public bool Haptic;
    }

    public struct PowerUpData
    {
        public bool DoubleShot;
        public bool TripleShot;
        public float HealthBoost;
        public float AttackDamage;
        public float DefenseBoost;
        public float Agility;
        public float RotatingGuns;
        public float Laser;
        public float Recoil;
        public float FuelEfficiency;
        public float GoldMultiplier;
        public float DiamondMultiplier;
    }

    public struct PlayerData
    {
        public string PlayerName;           // Oyuncunun adý
        public int PlayerLevel;             // Oyuncunun seviyesi
        public float Health;                // Oyuncunun saðlýðý
        public float Experience;            // Oyuncunun deneyimi
    }

    // Silah Bilgileri
    public struct WeaponData
    {
        public string WeaponName;           // Silahýn adý
        public int Damage;                  // Silahýn verdiði hasar
        public float FireRate;              // Ateþleme hýzý
        public bool IsEquipped;             // Silahýn ekipman olup olmadýðý
    }

    // Eþya Bilgileri
    public struct ItemData
    {
        public string ItemName;             // Eþyanýn adý
        public ItemTyes ItemType;           // Eþyanýn tipi (örneðin, tüketilebilir)
        public int Quantity;                // Eþyanýn miktarý
        public bool IsUsable;               // Eþyanýn kullanýlabilir olup olmadýðý
    }

    // Düþman Bilgileri
    public struct EnemyData
    {
        public string EnemyName;            // Düþmanýn adý
        public int MaxHealth;               // Düþmanýn maksimum saðlýðý
        public int AttackDamage;            // Düþmanýn saldýrý hasarý
        public float MovementSpeed;         // Düþmanýn hareket hýzý
    }

    // Görev Bilgileri
    public struct QuestData
    {
        public string QuestName;            // Görevin adý
        public string Description;          // Görev açýklamasý
        public bool IsCompleted;            // Görevin tamamlanýp tamamlanmadýðý
        public int ExperienceReward;        // Görevin verdiði deneyim ödülü
    }

    // Harita Bilgileri
    public struct MapData
    {
        public string MapName;              // Haritanýn adý
        public int MapSize;                 // Haritanýn boyutu
        public bool IsPlayable;             // Haritanýn oynanabilir olup olmadýðý
    }

    // Elbise Bilgileri
    public struct OutfitData
    {
        public string OutfitName;           // Elbisenin adý
        public Gender OutfitGender;         // Elbisenin cinsiyeti (erkek, kadýn, unisex)
        public ClothingTypes OutfitType;     // Elbisenin türü (üst giyim, alt giyim, aksesuar)
    }

    // Yetenek Bilgileri
    public struct AbilityData
    {
        public string AbilityName;          // Yeteneðin adý
        public int RequiredLevel;           // Yeteneðin gerektirdiði seviye
        public float Cooldown;              // Yeteneðin bekleme süresi
        public AbilityTypes AbilityType;     // Yeteneðin türü (saldýrý, savunma, destek)
    }

    // Zýrh Bilgileri
    public struct ArmorData
    {
        public string ArmorName;            // Zýrhýn adý
        public ArmorTypes ArmorType;         // Zýrhýn türü (zýrh seti, baþlýk, zýrh parçasý)
        public int DefensePoints;           // Zýrhýn savunma puanlarý
        public bool IsEquipped;             // Zýrhýn ekipman olup olmadýðý
    }

    public struct JoystickMovementParams
    {
        public float HorizontalInputValue;
        public float VerticalInputValue;
        public float HorizontalInputClampNegativeSide;
        public float HorizontalInputClampPositiveSide;
    }


    public class HorizontalInputParams
    {
        public float2 ClampValues;
        public float Xvalue;
    }
}
