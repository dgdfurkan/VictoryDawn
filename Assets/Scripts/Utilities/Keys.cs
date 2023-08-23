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
        public string PlayerName;           // Oyuncunun ad�
        public int PlayerLevel;             // Oyuncunun seviyesi
        public float Health;                // Oyuncunun sa�l���
        public float Experience;            // Oyuncunun deneyimi
    }

    // Silah Bilgileri
    public struct WeaponData
    {
        public string WeaponName;           // Silah�n ad�
        public int Damage;                  // Silah�n verdi�i hasar
        public float FireRate;              // Ate�leme h�z�
        public bool IsEquipped;             // Silah�n ekipman olup olmad���
    }

    // E�ya Bilgileri
    public struct ItemData
    {
        public string ItemName;             // E�yan�n ad�
        public ItemTyes ItemType;           // E�yan�n tipi (�rne�in, t�ketilebilir)
        public int Quantity;                // E�yan�n miktar�
        public bool IsUsable;               // E�yan�n kullan�labilir olup olmad���
    }

    // D��man Bilgileri
    public struct EnemyData
    {
        public string EnemyName;            // D��man�n ad�
        public int MaxHealth;               // D��man�n maksimum sa�l���
        public int AttackDamage;            // D��man�n sald�r� hasar�
        public float MovementSpeed;         // D��man�n hareket h�z�
    }

    // G�rev Bilgileri
    public struct QuestData
    {
        public string QuestName;            // G�revin ad�
        public string Description;          // G�rev a��klamas�
        public bool IsCompleted;            // G�revin tamamlan�p tamamlanmad���
        public int ExperienceReward;        // G�revin verdi�i deneyim �d�l�
    }

    // Harita Bilgileri
    public struct MapData
    {
        public string MapName;              // Haritan�n ad�
        public int MapSize;                 // Haritan�n boyutu
        public bool IsPlayable;             // Haritan�n oynanabilir olup olmad���
    }

    // Elbise Bilgileri
    public struct OutfitData
    {
        public string OutfitName;           // Elbisenin ad�
        public Gender OutfitGender;         // Elbisenin cinsiyeti (erkek, kad�n, unisex)
        public ClothingTypes OutfitType;     // Elbisenin t�r� (�st giyim, alt giyim, aksesuar)
    }

    // Yetenek Bilgileri
    public struct AbilityData
    {
        public string AbilityName;          // Yetene�in ad�
        public int RequiredLevel;           // Yetene�in gerektirdi�i seviye
        public float Cooldown;              // Yetene�in bekleme s�resi
        public AbilityTypes AbilityType;     // Yetene�in t�r� (sald�r�, savunma, destek)
    }

    // Z�rh Bilgileri
    public struct ArmorData
    {
        public string ArmorName;            // Z�rh�n ad�
        public ArmorTypes ArmorType;         // Z�rh�n t�r� (z�rh seti, ba�l�k, z�rh par�as�)
        public int DefensePoints;           // Z�rh�n savunma puanlar�
        public bool IsEquipped;             // Z�rh�n ekipman olup olmad���
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
