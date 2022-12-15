using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider health;
    public Slider boost;
    public Slider exp;
    private float boostcurtime;

    void Start()
    {
        health.maxValue = Player.Instance.GetMaxHealth();
        boost.maxValue = Player.Instance.GetBoosterCoolTime();
        exp.maxValue = Player.Instance.maxExp;
    }

    void Update()
    {
        health.value = Player.Instance.GetHealth(); //health
        if(Player.Instance.GetBooster())            //booster
        {
            if(boostcurtime < boost.maxValue)
            {
                boostcurtime += Time.deltaTime;
                boost.value = boostcurtime;
            }
        }
        else
        {
            boostcurtime = 0;
            boost.value = boost.maxValue;
        }
        exp.value = Player.Instance.exp;            //exp
    }
}