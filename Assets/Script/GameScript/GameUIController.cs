using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{

    public GameObject PausePanel;
    public Slider ProgressBar; 
    public Transform StartPoint;      
    public Transform EndPoint;
    private Transform _playerTransform;
    private float _totalDistance;

    
    private void Start()
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();
        _playerTransform = playerController.transform;
        _totalDistance = Vector3.Distance(StartPoint.position, EndPoint.position);
    }

    private void Update()
    {
        float distanceToGoal = Vector3.Distance(_playerTransform.position, EndPoint.position);
        float progress = 1f - (distanceToGoal / _totalDistance);
        ProgressBar.value = progress;

        if (progress >= 0.999f)
        {
            PauseGame();
        }
    }
    private void PauseButton()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogWarning("Pause Menu is not assigned!");
        }
    }

    private void BackToGame()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.LogWarning("Pause Menu is not assigned!");
        }
    }
    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

}
