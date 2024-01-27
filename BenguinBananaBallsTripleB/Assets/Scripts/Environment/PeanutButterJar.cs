using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeanutButterJar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager._Instance.ExitGame();
            LevelLoadManager._Instance.StartLoadNewLevel(LevelLoadManager._Instance.LevelNamesList[1], false);
        }
    }
}
