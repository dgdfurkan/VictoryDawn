using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GunduzDev
{
	public class SceneTransitionManager : MonoSingleton<SceneTransitionManager> 
    {
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            
        }

        private void UnsubscribeEvents()
        {
            
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadSceneAsync(1);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {

            }
        }

        public void NextScene()
        {
            Debug.Log("We are on next scene");

            int index = SceneManager.GetActiveScene().buildIndex;
            int total = SceneManager.sceneCountInBuildSettings;

            Debug.Log("Scene index : " + index);
            Debug.Log("Next index : " + (index < total && index != 0 ? index + 1 : index != 0 ? index - 1 : index));

            SceneManager.LoadScene(index < total && index != 0 ? index + 1 : index != 0 ? index - 1 : index);
            //SceneManager.LoadScene(index < total && index != 0 ? index + 1 : index - 1);
        }

        void PreviousScene()
        {
            Debug.Log("We are on previous scene");

            int index = SceneManager.GetActiveScene().buildIndex;
            int total = SceneManager.sceneCountInBuildSettings;

            Debug.Log("Scene index : " + index);
            Debug.Log("Scene index : " + (index > 1 ? index - 1 : index == 1 ? index + 1 : index));

            SceneManager.LoadScene(index > 1 ? index - 1 : index == 1 ? index + 1 : index);
        }
    }
}
