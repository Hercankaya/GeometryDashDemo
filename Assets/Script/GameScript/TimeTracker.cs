using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    private PlayerController _playerController;
    private float _startTime = -1;
    private TextMeshProUGUI _timeText;

    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _timeText = GameObject.Find("GameUI/PauseButton/PausePanel/TimeText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (_playerController != null && _playerController.PlayerLive)
        {
            if (_startTime == -1)
            {
                _startTime = Time.time;
            }

            float elapsedTime = Time.time - _startTime;
            string formattedTime = FormatTime(elapsedTime);
            _timeText.text = formattedTime;
        }
    }

    string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
