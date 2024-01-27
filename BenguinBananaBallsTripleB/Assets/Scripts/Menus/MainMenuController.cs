using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject confirmMenu;


    public void PlayButtonPressed()
    {
        if (confirmMenu.activeSelf) return;

        confirmMenu.SetActive(true);
    }

    public void SettingsButtonPressed()
    {

    }

    public void QuitButtonpressed()
    {

    }
}
