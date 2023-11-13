using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarPlayer : MonoBehaviour
{
    public int daño = 20;
    public Slider slider;
    public int life = 100;


    private void Update()
    {
        slider.value = life;
    }

    public void RecibirDaño(int Damage)
    {
        life -= daño;

        if (life <= 0)
        {
            GameManager.Instance.ShowGameOverScreen();
        }

    }
}
