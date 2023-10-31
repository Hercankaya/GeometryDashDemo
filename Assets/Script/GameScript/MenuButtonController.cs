
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtonController : MonoBehaviour
{
    public GameObject Active;

    public void GoToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void GoToCharacterSelectionScene()
    {
        SceneManager.LoadScene("CharacterSelectionScene");
    }
    public void BackToLoadingScene()
    {
        SceneManager.LoadScene("MenuScene");
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
