using UnityEngine;

public class ExpandUISingle : MonoBehaviour
{
    public float expansionRate = 0.1f; 

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) 
        {
            ExpandUI();
        }
    }

    void ExpandUI()
    {
        
        transform.localScale += Vector3.one * expansionRate;
    }
}