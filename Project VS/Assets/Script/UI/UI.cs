using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public Slider health;
    public Slider boost;
    public Slider exp;
    public TMP_Text PlayerLV;
    public TMP_Text WepLV;
    public TMP_Text Timer;
    public TMP_Text Score;
    Gun GunLV;
    BackShot BackShotLV;
    DmgFieldGenerator DamageFieldLV;
    Laser LaserLV;
    private float boostcurtime;
    string timertext;

    void Start()
    {
        health.maxValue = Player.Instance.GetMaxHealth();
        boost.maxValue = Player.Instance.GetBoosterCoolTime();
        GunLV = GameObject.FindGameObjectWithTag("Player").GetComponent<Gun>();
        BackShotLV = GameObject.FindGameObjectWithTag("Player").GetComponent<BackShot>();
        DamageFieldLV = GameObject.FindGameObjectWithTag("Player").GetComponent<DmgFieldGenerator>();
        LaserLV = GameObject.FindGameObjectWithTag("Player").GetComponent<Laser>();
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
        exp.maxValue = Player.Instance.maxExp;      //exp
        exp.value = Player.Instance.exp;        

        if(!Player.Instance.isDie) timertext = ((int)(GameManager.Instance.GetTimer() / 60)).ToString("D2") + ":" + ((int)(GameManager.Instance.GetTimer() % 60)).ToString("D2");

        PlayerLV.text = "Level: " + Player.Instance.playerLev;
        WepLV.text = "Gun: " + GunLV.weaponLev + "\n" + "BackShot: " + BackShotLV.weaponLev + "\n" + "DamageField: " + DamageFieldLV.weaponLev + "\n" + "Laser: " + LaserLV.weaponLev;
        Timer.text = timertext;
        Score.text = "Score: " + GameManager.Instance.gameScore;
    }
}