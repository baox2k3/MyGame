using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health PlaeyHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image curentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = PlaeyHealth.currenHealth / 10;
    }

    private void Update()
    {
        curentHealthBar.fillAmount = PlaeyHealth.currenHealth / 10;
    }
}
