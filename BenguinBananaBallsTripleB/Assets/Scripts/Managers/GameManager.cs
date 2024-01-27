using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _Instance;

    [SerializeField]
    private bool inGame = false;

    [SerializeField]
    private GameObject playerRootObject;

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
}
