using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadManager : MonoBehaviour
{
    // remove this 
    public bool loadLevelOnStart = false;
    
    public static LevelLoadManager _Instance;

    [SerializeField, ReadOnly]
    private bool isLoadingLevel = false;

    [SerializeField, ReadOnly]
    private List<string> currentLevelList;

    [SerializeField]
    private List<string> levelNamesList;

    [SerializeField]
    private LoadingScreen loadingScreen;

    // Getters
    public List<string> LevelNamesList { get { return levelNamesList; } }
    public bool IsLoadingLevel { get { return isLoadingLevel; } }

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
            Destroy(this.gameObject);
        else if (_Instance == null)
            _Instance = this;
    }

    // Initial Level Load
    private void Start()
    {
        if (!loadLevelOnStart) return;
        StartLoadNewLevel(levelNamesList[0]);
    }

    // Load a new level method
    public void StartLoadNewLevel(string levelName)
    {
        StartCoroutine(LoadLevel(levelName));
    }

    public void LoadMenuOverlay(string menuName)
    {
        SceneManager.LoadScene(menuName, LoadSceneMode.Additive);
        currentLevelList.Insert(0, menuName); // Insert at front
    }

    public void UnloadMenuOverlay(string menuName)
    {
        SceneManager.UnloadSceneAsync(currentLevelList[0]);
        currentLevelList.RemoveAt(0); // Remove first
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentLevelList[0])); // Set as active scene
    }

    // Coroutine to load level properly
    private IEnumerator LoadLevel(string sceneToLoad)
    {
        isLoadingLevel = true;

        loadingScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.25f);

        // Unload all opened scenes (Not the persistent scene
        if (currentLevelList.Count != 0)
        {
            for (int i = 0; i < currentLevelList.Count; i++)
                SceneManager.UnloadSceneAsync(currentLevelList[i]);
            currentLevelList.Clear();
        }

        // Load new scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            loadingScreen.UpdateSlider(asyncLoad.progress);
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoad));

        currentLevelList.Add(sceneToLoad);

        // Initialize player etc.
        yield return new WaitForSeconds(1f);

        isLoadingLevel = false;
        loadingScreen.gameObject.SetActive(false);

        yield break;
    }
}