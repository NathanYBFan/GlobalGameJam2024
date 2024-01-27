using System.Collections;
using System.Collections.Generic;
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
}
