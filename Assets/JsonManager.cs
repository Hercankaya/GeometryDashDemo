using UnityEngine;
using System.IO;

[System.Serializable]
public class MyData
{
    public string ProgressPercentage;
}

public class JsonManager : MonoBehaviour
{
    GameUIController _gameUIcontroller;
    private string jsonFileName = "progressData.json";

    void Start()
    {
        _gameUIcontroller = FindObjectOfType<GameUIController>();

        if (_gameUIcontroller == null)
        {
            Debug.LogError("GameUIController bulunamadý.");
        }
    }

    void Update()
    {
        if (_gameUIcontroller != null)
        {
            SaveProgressData(_gameUIcontroller.Progress);
        }
    }

    void SaveProgressData(float progress)
    {
        float progressPercentage = Mathf.Clamp01(progress) * 100f;
        MyData myData = new MyData();
        myData.ProgressPercentage = progressPercentage.ToString("F0") + "%";

        try
        {
            string json = JsonUtility.ToJson(myData);
            File.WriteAllText(Path.Combine(Application.dataPath, jsonFileName), json);
           // Debug.Log("ProgressData baþarýyla kaydedildi. Yüzde: " + myData.ProgressPercentage);
        }
        catch (System.Exception e)
        {
            Debug.LogError("ProgressData kaydedilirken hata oluþtu: " + e.Message);
        }
    }
}
