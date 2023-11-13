using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarPlayer : MonoBehaviour
{
    public int da�o = 20;
    public Slider slider;
    public int life = 100;


    private void Update()
    {
        slider.value = life;
    }

    public void RecibirDa�o(int Damage)
    {
        life -= da�o;

        if (life <= 0)
        {
            GameManager.Instance.ShowGameOverScreen();
        }

    }
}
