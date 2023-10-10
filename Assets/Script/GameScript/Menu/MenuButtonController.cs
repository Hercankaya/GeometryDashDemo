using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public GameObject Active;

    public void GoToNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogError("Next scene not found!");
        }

    }

    public void SettingPanelActive()
    {
        this.enabled = true;
        Active.SetActive(true);
    }
    public void SettingPanelDeactive()
    {
        this.enabled = false;
        Active.SetActive(false);
    }
}
