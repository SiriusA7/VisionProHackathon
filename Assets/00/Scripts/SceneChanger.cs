using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// 
/// </summary>
public class SceneChanger : MonoBehaviour
{
    #region Inspector Fields
    #endregion


    #region Public Properties
    #endregion


    #region Events
    #endregion


    #region Internal Variables
    private bool _finishLoading = false;
    #endregion


    #region Data Constructs
    #endregion


    #region MonoBehaviour Loop
    private void Awake()
    {
        
    }
    #endregion
    
    
    #region Event Handlers
    #endregion
    

    #region Internal Functions
    internal IEnumerator LoadScenePartially(int sceneIndex = 1)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        asyncLoad.allowSceneActivation = false;
        Debug.Log("Started loading the scene: " + sceneIndex);

        // Wait until the scene has loaded to 90%
        while (asyncLoad.progress < 0.9f)
        {
            Debug.Log("Loading progress: " + asyncLoad.progress);
            yield return null;
        }

        Debug.Log("Scene loaded to 90%, waiting for activation condition.");

        // Wait for the condition to fully load and activate the scene
        yield return new WaitUntil(() => _finishLoading);

        Debug.Log("Condition met, activating the scene.");
        asyncLoad.allowSceneActivation = true;
    }
    internal IEnumerator UnloadSceneAsync(int sceneIndex = 0)
    {
        // Start unloading the scene
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneIndex);

        // Wait until the scene is fully unloaded
        while (!asyncUnload.isDone)
        {
            // Here you can add code if you want to show the progress
            // e.g., a loading bar: progress = asyncUnload.progress;
            yield return null;
        }

        // Scene is fully unloaded, perform additional tasks here if needed
    }
    internal void SetAllowSceneActivation(bool allow)
    {
        _finishLoading = allow;
    }
    #endregion


    #region Public API
    #endregion
}
