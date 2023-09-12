using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject active;


     public void PauseButton()
    {
        active.SetActive(true);
        Time.timeScale = 0f;
        

    }
    public void BackToGame()
    {
        active.SetActive(false);
        Time.timeScale = 1f;

    }
}
