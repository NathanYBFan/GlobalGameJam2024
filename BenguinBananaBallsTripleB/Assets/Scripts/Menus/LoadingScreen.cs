using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    // Serialize Fields
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("The slider to adjust the value of")]
    private Slider loadingSlider;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("The slider to adjust the value of")]
    private TextMeshProUGUI textBox;

    private void OnEnable()
    {
        // Reset value
        loadingSlider.value = 0;
    }

    // Update slider values
    public void UpdateSlider(float value)
    {
        float progressAmount = Mathf.Clamp01(value / 0.9f); // Normalize to correct value
        loadingSlider.value = progressAmount;
    }

    public void UpdateText(string text)
    {
        textBox.text = text;
    }
}
