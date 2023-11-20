using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Ekle
using System.IO;
using UnityEngine.SceneManagement;

// Di�er using ifadeleri

public class LevelSelectController : MonoBehaviour
{
    public Slider CompletedLevelProgressBar;
    public TextMeshProUGUI progressText; 
    private string jsonFileName = "progressData.json";

    void Start()
    {
        LoadProgressData();
    }
    void LoadProgressData()
    {
        try
        {
            
            string jsonPath = Path.Combine(Application.dataPath, jsonFileName);
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                MyData myData = JsonUtility.FromJson<MyData>(json);

                float progressPercentage;

                if (float.TryParse(myData.ProgressPercentage.Replace("%", ""), out progressPercentage))
                {
                    
                    CompletedLevelProgressBar.value = progressPercentage / 100f;
                    progressText.text = myData.ProgressPercentage;
                   
                }
                else
                {
                    Debug.LogError("ProgressData y�zde de�eri okunurken hata olu�tu.");
                }
            }
            else
            {
                Debug.LogError("ProgressData dosyas� bulunamad�.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("ProgressData okunurken hata olu�tu: " + e.Message);
        }
    }

    private void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
