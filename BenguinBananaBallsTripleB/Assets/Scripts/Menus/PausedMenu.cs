using UnityEngine;

public class PausedMenu : MonoBehaviour
{
    public void ResumeButtonPressed()
    {
        GameManager._Instance.PauseGame();
    }

    public void SettingsMenuPressed()
    {
        LevelLoadManager._Instance.LoadMenuOverlay(LevelLoadManager._Instance.LevelNamesList[1]);
    }

    public void QuitButtonPressed()
    {
        GameManager._Instance.PauseGame();
        GameManager._Instance.InGame = false;
        LevelLoadManager._Instance.StartLoadNewLevel(LevelLoadManager._Instance.LevelNamesList[0], true);
    }
}