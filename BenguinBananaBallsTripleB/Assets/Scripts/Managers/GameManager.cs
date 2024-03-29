using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _Instance;

    [SerializeField]
    private bool inGame = false;

    [SerializeField]
    private GameObject playerRootObject;

    [SerializeField]
    private GameObject pauseMenu;

    public bool InGame { get { return inGame; } set { inGame = value; } }
    public GameObject PlayerRootObject { get { return playerRootObject; } set {  playerRootObject = value; } }

    private void Awake()
    {
        if ( _Instance != null && _Instance != this)
            Destroy(this.gameObject);
        else if (_Instance == null)
            _Instance = this;
    }

    public void StartGame()
    {
        playerRootObject.transform.position = Vector3.zero;
        playerRootObject.transform.parent.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        playerRootObject.transform.position = Vector3.zero;
        playerRootObject.transform.parent.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    //private void OnApplicationQuit()
    //{
    //    #if UNITY_STANDALONE_WIN
    //        UnityEngine.Debug.Log(Application.dataPath);
    //        Process p = new Process();
    //        p.StartInfo.UseShellExecute = true;
    //        p.StartInfo.FileName = System.IO.Path.GetDirectoryName(Application.dataPath) + "..\\BenguinBananaBallsTripleB.exe";
    //        p.Start();
    //        p.Start();
    //    #endif
    //}
}
