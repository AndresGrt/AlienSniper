﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Records : MonoBehaviour
{
    public int m;//numero de muertos
    public Text deads;//en canvas el numero de muertos
    public Text disparos;//en canvas el numero de disparos
    public Text headShoot;//en canvas el mensaje para ambientar
    public Text tiempo;//Control de tiempo en canvas
    float corret;//el tiempo para desaparecer el mensaje para ambientar
    float maxT;//el tiempo maximo para el tiempo anterior /\

    [SerializeField]
    int TMin;
    [SerializeField]
    int TSeg;
    [SerializeField]
    int TotalShoot;
    [SerializeField]
    int TotalDeads;

    private void Start()
    {
        maxT = 5;
        headShoot.enabled = !headShoot.enabled;
    }
    private void Update()
    {
        deads.text = "Muertes: " + m;
        disparos.text = "Disparos: " + FindObjectOfType<Disparo>().numDisparo;
    }
    public void RecorsGame()
    {
        TMin = FindObjectOfType<ControlTime>().minTotal;
        TSeg = FindObjectOfType<ControlTime>().segTotal;
        TotalShoot = FindObjectOfType<Disparo>().numDisparo;
        TotalDeads = m;

        FindObjectOfType<Disparo>().numDisparo = 0;
        m = 0;
    }
    public void TimeRun()
    {

        tiempo.text = "Time " + FindObjectOfType<ControlTime>().minutos + ":" + FindObjectOfType<ControlTime>().segundos;
    }
    public void TotalTime()
    {
        tiempo.text = "Tiempo total " + FindObjectOfType<ControlTime>().minTotal + ":" + FindObjectOfType<ControlTime>().segTotal;
    }
    public void HeadShoot()
    {
        headShoot.enabled = true;
        corret += Time.deltaTime;
        if (corret >= maxT)
        {
            headShoot.enabled = false;
            corret = 0;
            FindObjectOfType<Disparo>().activa = false;
        }
    }
}
