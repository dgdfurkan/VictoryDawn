using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GunduzDev
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public GameObject panel;
        public GameObject winPanel;
        public Button playButton;
        private void Awake()
        {
            Instance = this;
        }

        public void PlayButton()
        {
            panel.SetActive(false);
        }

        public void ExitGame()
        {
            Time.timeScale = 1.0f;
            Application.Quit();
        }

        public void AddListener()
        {
            playButton.onClick.AddListener(ChangeScene);
        }

        void ChangeScene()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
