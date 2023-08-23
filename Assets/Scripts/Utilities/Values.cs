using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

namespace GunduzDev.Values
{
    public static class SaveDataValues
    {
        public static string Score => "Score";
        public static string Gold => "Gold";
        public static string Diamand => "Diamand";
        public static string LevelID => "LevelID";
        public static string VehicleID => "VehicleID";
        public static string WeaponID => "WeaponID";
        public static string OwnedVehicles => "OwnedVehicles";
        public static string OwnedWeapons => "OwnedWeapons";

        public static int[] OwnedVehiclesYa;
    }

    public static class PoolingManagerValues
    {
        public static string Enemy => "Enemy";
        public static string Boss => "Boss";
        public static string Environment => "Environment";
        public static string Road => "Road";
        public static string Bullet => "Bullet";
    }

    public enum CollectableTypes
    {
        Gold,           // Represents gold collectibles
        Diamond         // Represents diamond collectibles
    }

    public enum GameStates
    {
        MainMenu,       // Represents the main menu state
        Gameplay,       // Represents the gameplay state
        Paused,         // Represents the paused state
        LevelCompleted, // Represents the level completed state
        LevelFailed, // Represents the level failed state
        GameOver        // Represents the game over state
    }

    public enum UIPanelTypes
    {
        Init,
        Menu,
        Shop,
        Settings,
        Upgrade,
        PowerUpSelection,
        Gameplay,
        LevelCompleted,
        LevelFailed,
        Pause,
    }

    public enum UIEventSubscriptionTypes
    {
        OnPlay,
        OnMenu,
        OnPause,
        OnResume,
        OnNextLevel,
        OnRestartLevel,
        OnShop,
        OnShopClose,
        OnSettings,
        OnSettingsClose
    }

    public enum AnimationStates
    {
        Idle,       // Represents the idle animation state
        Moving,     // Represents the moving animation state
        Shooting,   // Represents the shooting animation state
        TakingDamage,   // Represents the taking damage animation state
        Dying       // Represents the dying animation state
    }

    public enum PowerUpTypes
    {
        DoubleShot,         // Represents power-up that enables double shot
        TripleShot,         // Represents power-up that enables triple shot
        HealthBoost,        // Represents power-up that boosts health
        AttackDamage,       // Represents power-up that increases attack damage
        DefenseBoost,       // Represents power-up that boosts defense
        Agility,            // Represents power-up that enhances agility
        RotatingGuns,       // Represents power-up that adds rotating guns
        Laser,              // Represents power-up that improves the car's lasers
        Recoil,             // Represents power-up that increases bullet recoil
        FuelEfficiency,     // Represents power-up that reduces fuel consumption
        GoldMultiplier,     // Represents power-up that increases gold drop chance
        DiamondMultiplier   // Represents power-up that increases diamond drop chance
    }

    public enum EnvironmentTypes
    {
        City,           // Represents the city environment type
        Desert,         // Represents the desert environment type
        Forest,         // Represents the forest environment type
        Arctic,         // Represents the arctic environment type
        Space,         // Represents the space environment type
        Environment1,
        Environment2,
        Environment3
    }

    public enum ItemTyes
    {

    }

    public enum ClothingTypes
    {

    }

    public enum AbilityTypes
    {

    }

    public enum ArmorTypes
    {

    }

    public enum RoadPlacements
    {
        LeftRoad = -4,
        MiddleRoad = 0,
        RightRoad = 4,
        LeftOpposite = 8,
        RightOpposite = 12,
            
    }
}
