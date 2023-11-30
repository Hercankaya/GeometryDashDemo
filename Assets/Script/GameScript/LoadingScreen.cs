using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public Slider LoadingSlider; 
    private float _loadDelay = 5f; 
    private string _nextSceneName = "MenuScene"; 

    private void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(_loadDelay);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nextSceneName);

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); 
            LoadingSlider.value = progress;
            yield return new WaitForEndOfFrame(); 
       
        }
    }
}

