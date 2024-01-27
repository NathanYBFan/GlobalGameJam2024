using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandUI : MonoBehaviour
{
    public Button expandButton;
    public Image expandImage; // incase we want to do this for images
    public Slider expandSlider; // for sliders
    public float maxSize = 300f; 
    public float expansionSpeed = 50f; 

    private RectTransform buttonRectTransform;
    private RectTransform imageRectTransform; // incase we want to do this for images
    private RectTransform sliderRectTransform; // for sliders
    private void Start()
    {
        if (expandButton == null)
        {
            Debug.LogError("Button not assigned!");
            
            return;
        }

        if (expandImage == null)
        {
            Debug.LogError("Image not assigned!");
            return;
        }

        if (expandSlider == null)
        {
            Debug.LogError("Slider not assigned!");
            return;
        }
        buttonRectTransform = expandButton.GetComponent<RectTransform>();
        imageRectTransform = expandImage.GetComponent<RectTransform>();
        sliderRectTransform = expandSlider.GetComponent<RectTransform>();

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            expandButtonUI();
            expandImageUI();
            expandSliderUI();

        }
    }
    private void expandButtonUI()
    {
        
            
            float newSize = Mathf.Min(buttonRectTransform.sizeDelta.x + expansionSpeed * Time.deltaTime, maxSize);
            
            buttonRectTransform.sizeDelta = new Vector2(newSize, buttonRectTransform.sizeDelta.y);
        
    }
    private void expandImageUI()
    {

        float newImageSize = Mathf.Min(imageRectTransform.sizeDelta.x + expansionSpeed * Time.deltaTime, maxSize);


        imageRectTransform.sizeDelta = new Vector2(newImageSize, imageRectTransform.sizeDelta.y);

    }
    private void expandSliderUI()
    {

        float newSliderSize = Mathf.Min(sliderRectTransform.sizeDelta.x + expansionSpeed * Time.deltaTime, maxSize);

        sliderRectTransform.sizeDelta = new Vector2(newSliderSize, sliderRectTransform.sizeDelta.y);

    }
}
