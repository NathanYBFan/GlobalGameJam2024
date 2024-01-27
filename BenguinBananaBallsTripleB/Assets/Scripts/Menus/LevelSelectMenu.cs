using UnityEngine;

public class LevelSelectMenu : MonoBehaviour
{
    [SerializeField]
    private string[] nameOfLevelsToLoad;

    public void LevelSelected(int levelIndex)
    {
        if (levelIndex > nameOfLevelsToLoad.Length) return;
        LevelLoadManager._Instance.StartLoadNewLevel(nameOfLevelsToLoad[levelIndex]);
    }
}
