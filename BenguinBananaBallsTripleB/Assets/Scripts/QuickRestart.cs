using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody rigidbody;
    void Update()
    {
        if (Input.GetButton("QuickRestart"))
        {
            resetTheGame();
        }
    }
    public void resetTheGame()
    {
        if (rigidbody != null)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
