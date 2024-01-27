using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject confirmMenu;

    [SerializeField]
    private GameObject hintMenuPrefab;

    public void PlayButtonPressed()
    {
        if (confirmMenu.activeSelf) return;

        confirmMenu.SetActive(true);
    }

    public void SettingsButtonPressed(GameObject spawnposition)
    {
        GameObject.Instantiate(hintMenuPrefab, spawnposition.transform.position, Quaternion.identity, gameObject.transform);
    }

    public void RealPlayButtonPressed(string nextSceneToload)
    {
        SceneManager.LoadScene(nextSceneToload, LoadSceneMode.Single);
    }
}
