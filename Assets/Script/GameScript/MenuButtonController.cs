
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtonController : MonoBehaviour
{
    public GameObject Active;

    private void GoToGameLevelSelectionScene()
    {
        SceneManager.LoadScene("LevelSelectionScene");
    }
    private void GoToCharacterSelectionScene()
    {
        SceneManager.LoadScene("CharacterSelectionScene");
    }
    private void BackToLoadingScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void SettingPanelActive()
    {
        this.enabled = true;
        Active.SetActive(true);
    }
    private void SettingPanelDeactive()
    {
        this.enabled = false;
        Active.SetActive(false);
    }
}
