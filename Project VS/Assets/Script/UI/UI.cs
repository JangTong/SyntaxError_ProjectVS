using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider health;
    public Slider boost;
    private float boostcurtime;

    void Start()
    {
        health.maxValue = Player.Instance.GetMaxHealth();
        boost.maxValue = Player.Instance.GetBoosterCoolTime();
    }

    void Update()
    {
        health.value = Player.Instance.GetHealth();
        if(Player.Instance.GetBooster())
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
    }
}