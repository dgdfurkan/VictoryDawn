using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GunduzDev.Keys;
using GunduzDev.Values;
using Unity.Mathematics;

namespace GunduzDev
{
    public static class SignalManager
    {
        #region Level Signals
        public static UnityAction<int> onLevelInitialize = delegate { }; // Triggered when a level is initialized, with the level ID as a parameter.
        public static UnityAction<int> onSetNewLevelValue = delegate { };
        public static UnityAction onLoadCurrentLevelValues = delegate { };
        public static UnityAction<int, string> onSetCurrentLevelValue = delegate { };
        public static UnityAction<float> onSetEnemyPassValue = delegate { };
        public static UnityAction onResetEnemyPassValue = delegate { };
        public static UnityAction<float> onSetBossPassValue = delegate { };
        public static UnityAction onResetBossPassValue = delegate { };
        public static UnityAction<int> onSetStageColor = delegate { };
        public static UnityAction onClearActiveLevel = delegate { }; // Triggered when the active level is cleared.
        public static UnityAction onLevelFailed = delegate { }; // Triggered when a level is failed.
        public static UnityAction onLevelSuccessful = delegate { }; // Triggered when a level is successfully completed.
        public static UnityAction onPlay = delegate { }; // Triggered when game plays.
        public static UnityAction onLevelNext = delegate { }; // Triggered when transitioning to the next level.
        public static UnityAction onNextScene = delegate { }; // Triggered when transitioning to the next scene.
        public static UnityAction onPreviousScene = delegate { }; // Triggered when transitioning to the previous scene.
        public static UnityAction onLevelRestart = delegate { }; // Triggered when a level is restarted.
        public static UnityAction onLevelReset = delegate { }; // Triggered when a level is reseted.
        public static UnityAction onLevelCompletedd = delegate { }; // Triggered when the player completes a level.
        public static UnityAction onLevelCompleted = delegate { }; // Triggered when the player wins the game.
        #endregion



        #region Game Save Signals
        public static UnityAction<GameSaveData> onSaveGameData = delegate { }; // Triggered when game data is saved, with the save data as a parameter.
        public static UnityAction<GameSaveData> onLoadGameData = delegate { }; // Triggered when game data is loaded, with the loaded data as a parameter.
        #endregion



        #region UI Signals
        public static UnityAction<UIPanelTypes,int> onOpenPanel = delegate { }; // Triggered when a panel is opened, with the panel ID as a parameter.
        public static UnityAction<int> onClosePanel = delegate { }; // Triggered when a panel is closed, with the panel ID as a parameter.
        public static UnityAction onCloseAllPanels = delegate { }; // Triggered when all panels are closed.
        #endregion



        #region Audio Signals
        public static UnityAction<AudioTypes> onMusicPlay = delegate { }; // Triggered when a sound is played, with the music clip as a parameter.
        public static UnityAction onMusicStop = delegate { }; // Triggered when a sound is stopped, with the msuic clip.
        public static UnityAction<AudioTypes> onSFXPlay = delegate { }; // Triggered when a sound is played, with the SFX clip as a parameter.
        public static UnityAction onButtonSFXPlay = delegate { }; // Triggered when a sound is played, with the SFX clip as a parameter.
        public static UnityAction onSFXStop = delegate { }; // Triggered when a sound is stopped, with the SFX clip as a parameter.
        public static UnityAction onSFXRandom = delegate { }; // Triggered when a sound is played, with the SFX clip.
        #endregion


        public static UnityAction OnPlayerGetDamage = delegate { };
        public static UnityAction OnPlayerGetHeal = delegate { };
        public static UnityAction OnPlayerDead = delegate { };
    }
}

