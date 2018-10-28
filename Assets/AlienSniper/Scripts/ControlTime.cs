﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTime : MonoBehaviour
{
    [SerializeField]
    float s;
    [SerializeField]
    float sT;
    [SerializeField]
    float mT;

    public int minutos;
    public int segundos;

    public int minTotal;
    public int segTotal;

    public void Start()
    {
        min = minutos;
        seg = segundos;
        s = segundos;
    }
    private void Update()
    {
        if ((minutos == 0 && segundos == 0) || (FindObjectOfType<ManangerEnemy>().contadorE == 0))
        {
            Guarda();
        }
        else
        {
            CorreTime();
        }
    }
    public void CorreTime()
    {
        s -= Time.deltaTime;
        sT += Time.deltaTime;
        if (s <= 0)
        {
            s = 60;
            minutos -= 1;
        }
        if (sT >= 60)
        {
            sT = 0;
            mT += 1;
        }
        segundos = (int)s;
        FindObjectOfType<Records>().TimeRun();
    }
    public void Guarda()
    {
        if ((minutos == 0 && segundos == 0))
        {
            segTotal = seg;
            minTotal = min;
        }
        else
        {
            segTotal = (int)sT;
            minTotal = (int)mT;
        }
        GameOver();
    }
    public void GameOver()
    {
        s = 0;
        minutos = 0;
        FindObjectOfType<Records>().TotalTime();
        FindObjectOfType<Menu>().activo = true;
    }
    public int min;
    public int seg;
    public void ResetTime()
    {
        s = seg;
        minutos = min;
        sT = 0;
        mT = 0;
        FindObjectOfType<Menu>().activo = false;
        FindObjectOfType<ManangerEnemy>().Reset();
        FindObjectOfType<Records>().RecorsGame();
    }
}