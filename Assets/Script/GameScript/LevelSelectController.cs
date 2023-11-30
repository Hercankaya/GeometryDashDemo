using UnityEngine;
using UnityEngine.UI;
using TMPro;  
using System.IO;
using UnityEngine.SceneManagement;


public class LevelSelectController : MonoBehaviour
{
    public Slider CompletedLevelProgressBar;
    public TextMeshProUGUI progressText; 
    private string _jsonFileName = "progressData.json";

    private void Start()
    {
        LoadProgressData();
    }
    private void LoadProgressData()
    {
        try
        {
            
            string jsonPath = Path.Combine(Application.dataPath, _jsonFileName);
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
                    Debug.LogError("ProgressData yüzde deðeri okunurken hata oluþtu.");
                }
            }
            else
            {
                Debug.LogError("ProgressData dosyasý bulunamadý.");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("ProgressData okunurken hata oluþtu: " + e.Message);
        }
    }
    private void GameScene()
    {
        SceneManager.LoadScene("GameScene1");
    } 
    public void GameSceneTwo()
    {
        SceneManager.LoadScene("GameScene2");
    }
    public void GameSceneThree()
    {
        SceneManager.LoadScene("GameScene3");
    }
    public void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
