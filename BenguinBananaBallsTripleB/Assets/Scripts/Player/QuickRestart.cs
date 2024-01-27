using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody rb;
    void Update()
    {
        if (Input.GetButton("QuickRestart"))
        {
            resetTheGame();
        }
    }
    public void resetTheGame()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
