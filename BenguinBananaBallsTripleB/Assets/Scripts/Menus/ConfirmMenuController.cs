using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConfirmMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buttons = new GameObject[2];

    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private string[] responses;

    private int index;
    private bool pass;

    private void Awake()
    {
        index = 0;
        title.text = "Are you sure you wanna quit?";
        buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = "No";
        buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = "Yes";
        pass = false;
    }

    public void ButtonPressed(TextMeshProUGUI textBox)
    {
        if (textBox.text == "No") ResetConfirmMenu();
        
        else if (index >= responses.Length)
        {
            if (textBox.text == "No") ResetConfirmMenu();
            else
            {
                buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = "Yes";
                buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = "No";
                if (!pass)
                {
                    pass = true;
                    return;
                }

#if UNITY_STANDALONE_WIN
                Application.Quit();
#endif

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            }
        }

        else if (textBox.text == "Yes")
        {
            title.text = responses[index];
            index++;
        }
        
        else
            Debug.Log("Unaccounted for error");
    }

    private void ResetConfirmMenu()
    {
        index = 0;
        
        buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = "No";
        buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = "Yes";
        pass = false;

        gameObject.SetActive(false);
    }
}
