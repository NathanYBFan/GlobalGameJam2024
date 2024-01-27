using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public float health;
    [SerializeField]    
    public float MaxhitPoints = 3f;


    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;

    public void Start()
    {
        health = MaxhitPoints;
    }
    
    void Update()
    {
        if(health > MaxhitPoints)
        {
            health = MaxhitPoints;
        }
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i <health)
            {
                hearts[i].sprite = fullheart;
            }
            else
            {
                hearts[i].sprite = emptyheart; 
            }
            if(i < MaxhitPoints ){
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
